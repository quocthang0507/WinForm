namespace TypingMaster
{
	public class User
	{
		private string name;
		private int age;
		private string gender;
		private int score;

		public User()
		{

		}

		public User(string name, int age, string gender)
		{
			this.Name = name;
			this.Age = age;
			this.gender = gender;
			this.Score = 0;
		}

		public string Name { get => name; set => name = value; }
		public int Age { get => age; set => age = value; }
		public string Gender { get => gender; set => gender = value; }
		public int Score { get => score; set => score = value; }
	}
}
