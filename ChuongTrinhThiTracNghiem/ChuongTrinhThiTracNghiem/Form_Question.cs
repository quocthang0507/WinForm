using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChuongTrinhThiTracNghiem
{
	public partial class Form_Question : Form
	{
		int remainingTime, time;
		string username;
		float score = 0;    //The user have gotten score
		int n;              //The current index of list
		int t;              //Total number of questions in list
		bool isRandom = false;  //Check whether the list is random

		List_Question data = new List_Question();

		public Form_Question()
		{
			Form_Welcome frm = new Form_Welcome();
			frm.ShowDialog();
			InitializeComponent();
			username = frm.tbx_Ten.Text;
			time = int.Parse(frm.tbx_ThoiGian.Text);
			if (frm.chk_Random.Checked)
				isRandom = true;
			frm.Close();
		}

		private void Form_Question_Load(object sender, EventArgs e)
		{
			label1.Text = "Thí sinh: " + username;
			LoadQuestions();
			Form_Load();
		}

		void Form_Load()
		{
			remainingTime = time;
			lbl_Remaining.Text = remainingTime + " phút";
			n = 0;
			ShowQuestion();
			timer1.Start();
			btnThoat.Enabled = false;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			remainingTime--;
			lbl_Remaining.Text = remainingTime + " phút";
			if (remainingTime == 0)
			{
				timer1.Stop();
				MessageBox.Show("Hết giờ!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				btn_NopBai.PerformClick();
			}
		}

		/// <summary>
		/// Randomly shuffle a list
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		static void Shuffle<T>(IList<T> list)
		{
			int n = list.Count;
			Random rng = new Random();
			while (n > 1)
			{
				n--;
				int k = rng.Next(n + 1);
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}

		/// <summary>
		/// Load entire questions from file
		/// </summary>
		void LoadQuestions()
		{
			Microsoft_Excel xls = new Microsoft_Excel();
			List_Question lq = new List_Question();
			string path;
			do
			{
				path = Microsoft_Excel.OpenFile();
				if (path == null)
				{
					MessageBox.Show(new Form() { WindowState = FormWindowState.Maximized, TopMost = true }, "Không có thư viện câu hỏi nên chương trình sẽ tự động thoát!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					Exit();
				}
				lq = xls.ToList(path);
				t = lq.list.Count;
				if (t == 0)
					MessageBox.Show("Dữ liệu câu hỏi rỗng!!! Vui lòng chọn tập tin khác");
			} while (t == 0);
			if (isRandom)
				Shuffle(lq.list);
			data = lq;
		}

		/// <summary>
		/// Show questions and multi choice answers to group box
		/// </summary>
		void ShowQuestion()
		{
			Question q = data[n];
			groupBox1.Text = "Câu " + (n + 1) + " / " + t;
			lbl_CauHoi.Text = q.question;
			radioButton1.Text = q.answers[0];
			radioButton2.Text = q.answers[1];
			radioButton3.Text = q.answers[2];
			radioButton4.Text = q.answers[3];
			ShowYourAnswer();
		}

		/// <summary>
		/// Record your current answer
		/// </summary>
		void RecordYourAnswer()
		{
			if (radioButton1.Checked)
				data[n].selectedAns = 1;
			else if (radioButton2.Checked)
				data[n].selectedAns = 2;
			else if (radioButton3.Checked)
				data[n].selectedAns = 3;
			else if (radioButton4.Checked)
				data[n].selectedAns = 4;
		}

		/// <summary>
		/// Show your answer of this question
		/// </summary>
		void ShowYourAnswer()
		{
			if (data[n].selectedAns == 0)   //Not choose any answer
				radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = radioButton4.Checked = false;
			else if (data[n].selectedAns == 1)
				radioButton1.Checked = true;
			else if (data[n].selectedAns == 2)
				radioButton2.Checked = true;
			else if (data[n].selectedAns == 3)
				radioButton3.Checked = true;
			else radioButton4.Checked = true;
		}

		/// <summary>
		/// Move on to the next question
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Sau_Click(object sender, EventArgs e)
		{
			if (n < t)
			{
				RecordYourAnswer();
				n++;
				ShowQuestion();
			}
		}

		/// <summary>
		/// Move on to the previous question
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Truoc_Click(object sender, EventArgs e)
		{
			if (n > 0)
			{
				RecordYourAnswer();
				n--;
				ShowQuestion();
			}
		}

		/// <summary>
		/// Calculate and return your score
		/// </summary>
		/// <returns>Your score</returns>
		float GetResult()
		{
			float mark = 10f / t;
			foreach (var item in data.list)
				if (item.correctAns == item.selectedAns)
					score += mark;
			return score;
		}

		private void Form_Question_FormClosing(object sender, FormClosingEventArgs e)
		{
			Exit();
		}

		/// <summary>
		/// Terminate the progress
		/// </summary>
		void Exit()
		{
			Environment.Exit(1);
		}

		/// <summary>
		/// Finish the exam
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_NopBai_Click(object sender, EventArgs e)
		{
			DialogResult d = MessageBox.Show("Bạn có chắc chắn nộp bài?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
			if (d == DialogResult.OK)
			{
				GetResult();
				if (score == 10)
					MessageBox.Show("Thật tuyệt vời! Bạn được 10 điểm", "Kết quả");
				else if (score >= 8)
					MessageBox.Show("Tốt lắm, được " + score + " điểm", "Kết quả");
				else if (score >= 6)
					MessageBox.Show("Khá lắm, được " + score + " điểm", "Kết quả");
				else MessageBox.Show(score + " điểm, cần cố gắng nhiều hơn", "Kết quả");
				btnThoat.Enabled = true;
				Reload();
			}
		}

		/// <summary>
		/// Reset your answer (no choice)
		/// </summary>
		void ResetYourAnswer()
		{
			foreach (var item in data.list)
				item.selectedAns = 0;
			score = 0;
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			Exit();
		}

		/// <summary>
		/// Reload the group box
		/// </summary>
		void Reload()
		{
			ResetYourAnswer();
			DialogResult d = MessageBox.Show("Bạn có muốn làm lại không?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
			if (d == DialogResult.OK)
				Form_Load();
			else
			{
				btn_NopBai.Enabled = false;
				groupBox1.Enabled = false;
			}
		}
	}
}
