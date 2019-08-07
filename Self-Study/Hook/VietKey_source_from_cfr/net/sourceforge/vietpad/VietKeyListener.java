/*
 * Decompiled with CFR 0.139.
 */
package net.sourceforge.vietpad;

import java.awt.Component;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.io.PrintStream;
import java.text.BreakIterator;
import java.util.Properties;
import javax.swing.ComboBoxEditor;
import javax.swing.JComboBox;
import javax.swing.text.BadLocationException;
import javax.swing.text.Document;
import javax.swing.text.JTextComponent;
import net.sourceforge.vietpad.InputMethods;
import net.sourceforge.vietpad.VietKey;

public class VietKeyListener
extends KeyAdapter {
    private JTextComponent textComponent;
    private static InputMethods inputMethod = InputMethods.Telex;
    private static boolean smartMarkOn;
    private static boolean vietModeOn;
    private static boolean paliSanskritDegaOn;
    private int start;
    private int end;
    private String curWord;
    private String vietWord;
    private char curChar;
    private char vietChar;
    private char keyChar;
    private char accent;
    private static Properties macroMap;
    private static boolean repeatKeyConsumed;
    private static final char ESCAPE_CHAR = '\\';
    private static final String SHIFTING_CHARS = "cmnpt";
    private static final String VOWELS = "aeiouy";
    private static final String NON_ACCENTS = "!@#$%&)_={}[]|:;/>,";
    private static final int MODIFIER_MASK = 896;
    private static final BreakIterator boundary;

    public VietKeyListener(JTextComponent textComponent) {
        this.textComponent = textComponent;
    }

    public VietKeyListener(JComboBox comboBox) {
        JTextComponent textComponent = (JTextComponent)comboBox.getEditor().getEditorComponent();
        textComponent.addKeyListener(new VietKeyListener(textComponent));
    }

    public static void setVietModeEnabled(boolean mode) {
        vietModeOn = mode;
    }

    public static void setPaliSanskritModeEnabled(boolean mode) {
        paliSanskritDegaOn = mode;
    }

    public static void setInputMethod(InputMethods method) {
        inputMethod = method;
    }

    public static InputMethods getInputMethod() {
        return inputMethod;
    }

    public static void setSmartMark(boolean smartMark) {
        smartMarkOn = smartMark;
    }

    public static void setDiacriticsPosClassic(boolean classic) {
        VietKey.setDiacriticsPosClassic(classic);
    }

    public static void setMacroMap(Properties shortHandMap) {
        macroMap = shortHandMap;
    }

    public void keyTyped(KeyEvent e) {
        int caretpos = this.textComponent.getCaretPosition();
        if (caretpos == 0 || (e.getModifiersEx() & 896) != 0) {
            return;
        }
        Document doc = this.textComponent.getDocument();
        try {
            this.curChar = doc.getText(caretpos - 1, 1).charAt(0);
        }
        catch (BadLocationException exc) {
            System.err.println(exc.getMessage());
        }
        if (this.curChar != '\\' && !Character.isLetter(this.curChar)) {
            return;
        }
        this.keyChar = e.getKeyChar();
        if (this.keyChar == ' ' && macroMap != null) {
            try {
                String key = this.getCurrentWord(caretpos, doc.getText(0, doc.getLength()));
                if (macroMap.containsKey(key)) {
                    String value = macroMap.getProperty(key);
                    this.textComponent.select(this.start, this.end);
                    this.textComponent.replaceSelection(value);
                    e.consume();
                    return;
                }
            }
            catch (BadLocationException exc) {
                System.err.println(exc.getMessage());
            }
        }
        if (!vietModeOn) {
            return;
        }
        if (Character.isWhitespace(this.keyChar) || NON_ACCENTS.indexOf(this.keyChar) != -1 || this.keyChar == '\b') {
            return;
        }
        try {
            this.curWord = this.getCurrentWord(caretpos, doc.getText(0, doc.getLength()));
        }
        catch (BadLocationException exc) {
            System.err.println(exc.getMessage());
        }
        if (smartMarkOn && this.curWord.length() >= 2 && (SHIFTING_CHARS.indexOf(Character.toLowerCase(this.keyChar)) >= 0 || VOWELS.indexOf(Character.toLowerCase(this.keyChar)) >= 0)) {
            try {
                String newWord;
                if (this.curWord.length() == 2 && VOWELS.indexOf(Character.toLowerCase(this.keyChar)) >= 0 && (this.curWord.toLowerCase().startsWith("q") || this.curWord.toLowerCase().startsWith("g")) && !(newWord = VietKey.shiftAccent(this.curWord + this.keyChar, this.keyChar)).equals(this.curWord + this.keyChar)) {
                    this.textComponent.select(this.start, this.end);
                    this.textComponent.replaceSelection(newWord);
                    e.consume();
                    return;
                }
                newWord = VietKey.shiftAccent(this.curWord, this.keyChar);
                if (!newWord.equals(this.curWord)) {
                    this.textComponent.select(this.start, this.end);
                    this.textComponent.replaceSelection(newWord);
                    this.curWord = newWord;
                }
            }
            catch (StringIndexOutOfBoundsException exc) {
                System.err.println("Caret out of bound! (For Shifting Marks)");
            }
        }
        this.accent = this.getAccentMark(this.keyChar);
        try {
            if (Character.isDigit(this.accent)) {
                if (smartMarkOn) {
                    String string = this.vietWord = this.curChar == '\\' ? String.valueOf(this.keyChar) : VietKey.toVietWord(this.curWord, this.accent);
                    if (!this.vietWord.equals(this.curWord)) {
                        this.textComponent.select(this.start, this.end);
                        this.textComponent.replaceSelection(this.vietWord);
                        if (!VietKey.isAccentRemoved() || repeatKeyConsumed) {
                            e.consume();
                        }
                    }
                } else {
                    char c = this.vietChar = this.curChar == '\\' ? this.keyChar : VietKey.toVietChar(this.curChar, this.accent);
                    if (this.vietChar != this.curChar) {
                        this.textComponent.select(caretpos - 1, caretpos);
                        this.textComponent.replaceSelection(String.valueOf(this.vietChar));
                        if (!VietKey.isAccentRemoved() || repeatKeyConsumed) {
                            e.consume();
                        }
                    }
                }
            } else if (this.accent != '\u0000' && paliSanskritDegaOn) {
                char phanChar = this.curChar == '\\' ? this.keyChar : this.accent;
                this.textComponent.select(caretpos - 1, caretpos);
                this.textComponent.replaceSelection(String.valueOf(phanChar));
                e.consume();
            }
        }
        catch (StringIndexOutOfBoundsException exc) {
            System.err.println("Caret out of bound!");
        }
    }

    public static void consumeRepeatKey(boolean mode) {
        repeatKeyConsumed = mode;
    }

    private char getAccentMark(char keyChar) {
        char accent = '\u0000';
        if (inputMethod == InputMethods.VNI) {
            if (Character.isDigit(keyChar)) {
                accent = keyChar;
            }
        } else if (inputMethod == InputMethods.VIQR) {
            int phanChar = 0;
            if (!Character.isLetterOrDigit(keyChar)) {
                block0 : switch (keyChar) {
                    case '\'': {
                        accent = '1';
                        break;
                    }
                    case '`': {
                        accent = '2';
                        break;
                    }
                    case '?': {
                        accent = '3';
                        break;
                    }
                    case '~': {
                        accent = '4';
                        switch (this.curChar) {
                            case 'R': {
                                phanChar = 7772;
                                break block0;
                            }
                            case 'r': {
                                phanChar = 7773;
                                break block0;
                            }
                            case 'L': {
                                phanChar = 7736;
                                break block0;
                            }
                            case 'l': {
                                phanChar = 7737;
                                break block0;
                            }
                            case 'N': {
                                phanChar = 209;
                                break block0;
                            }
                            case 'n': {
                                phanChar = 241;
                            }
                        }
                        break;
                    }
                    case '.': {
                        accent = '5';
                        switch (this.curChar) {
                            case 'R': {
                                phanChar = 7770;
                                break block0;
                            }
                            case 'r': {
                                phanChar = 7771;
                                break block0;
                            }
                            case 'L': {
                                phanChar = 7734;
                                break block0;
                            }
                            case 'l': {
                                phanChar = 7735;
                                break block0;
                            }
                            case 'M': {
                                phanChar = 7746;
                                break block0;
                            }
                            case 'm': {
                                phanChar = 7747;
                                break block0;
                            }
                            case 'H': {
                                phanChar = 7716;
                                break block0;
                            }
                            case 'h': {
                                phanChar = 7717;
                                break block0;
                            }
                            case 'T': {
                                phanChar = 7788;
                                break block0;
                            }
                            case 't': {
                                phanChar = 7789;
                                break block0;
                            }
                            case 'D': {
                                phanChar = 7692;
                                break block0;
                            }
                            case 'd': {
                                phanChar = 7693;
                                break block0;
                            }
                            case 'N': {
                                phanChar = 7750;
                                break block0;
                            }
                            case 'n': {
                                phanChar = 7751;
                                break block0;
                            }
                            case 'S': {
                                phanChar = 7778;
                                break block0;
                            }
                            case 's': {
                                phanChar = 7779;
                            }
                        }
                        break;
                    }
                    case '^': {
                        accent = '6';
                        break;
                    }
                    case '*': 
                    case '+': {
                        accent = '7';
                        break;
                    }
                    case '(': {
                        accent = '8';
                        switch (this.curChar) {
                            case 'E': {
                                phanChar = 276;
                                break block0;
                            }
                            case 'e': {
                                phanChar = 277;
                                break block0;
                            }
                            case 'I': {
                                phanChar = 300;
                                break block0;
                            }
                            case 'i': {
                                phanChar = 301;
                                break block0;
                            }
                            case 'O': {
                                phanChar = 334;
                                break block0;
                            }
                            case 'o': {
                                phanChar = 335;
                                break block0;
                            }
                            case 'U': {
                                phanChar = 364;
                                break block0;
                            }
                            case 'u': {
                                phanChar = 365;
                            }
                        }
                        break;
                    }
                    case '-': {
                        accent = '0';
                        break;
                    }
                    case '\"': {
                        switch (this.curChar) {
                            case 'M': {
                                phanChar = 7744;
                                break block0;
                            }
                            case 'm': {
                                phanChar = 7745;
                                break block0;
                            }
                            case 'N': {
                                phanChar = 7748;
                                break block0;
                            }
                            case 'n': {
                                phanChar = 7749;
                                break block0;
                            }
                            case 'S': {
                                phanChar = 346;
                                break block0;
                            }
                            case 's': {
                                phanChar = 347;
                                break block0;
                            }
                            case '\\': {
                                phanChar = 34;
                            }
                        }
                        break;
                    }
                    case '<': {
                        switch (this.curChar) {
                            case 'C': {
                                phanChar = 268;
                                break block0;
                            }
                            case 'c': {
                                phanChar = 269;
                                break block0;
                            }
                            case 'E': {
                                phanChar = 282;
                                break block0;
                            }
                            case 'e': {
                                phanChar = 283;
                                break block0;
                            }
                            case '\\': {
                                phanChar = 60;
                            }
                        }
                    }
                }
            } else if (keyChar == 'D' || keyChar == 'd') {
                accent = '9';
            } else {
                switch (keyChar) {
                    case 'A': {
                        if (this.curChar != 'A') break;
                        phanChar = 256;
                        break;
                    }
                    case 'a': {
                        if (this.curChar != 'a') break;
                        phanChar = 257;
                        break;
                    }
                    case 'I': {
                        if (this.curChar != 'I') break;
                        phanChar = 298;
                        break;
                    }
                    case 'i': {
                        if (this.curChar != 'i') break;
                        phanChar = 299;
                        break;
                    }
                    case 'U': {
                        if (this.curChar != 'U') break;
                        phanChar = 362;
                        break;
                    }
                    case 'u': {
                        if (this.curChar != 'u') break;
                        phanChar = 363;
                        break;
                    }
                    case 'E': {
                        if (this.curChar != 'E') break;
                        phanChar = 274;
                        break;
                    }
                    case 'e': {
                        if (this.curChar != 'e') break;
                        phanChar = 275;
                        break;
                    }
                    case 'O': {
                        if (this.curChar != 'O') break;
                        phanChar = 332;
                        break;
                    }
                    case 'o': {
                        if (this.curChar != 'o') break;
                        phanChar = 333;
                    }
                }
            }
            if (phanChar != 0 && paliSanskritDegaOn) {
                return (char)phanChar;
            }
        } else if (inputMethod == InputMethods.Telex && Character.isLetter(keyChar)) {
            switch (keyChar) {
                case 'S': 
                case 's': {
                    accent = '1';
                    break;
                }
                case 'F': 
                case 'f': {
                    accent = '2';
                    break;
                }
                case 'R': 
                case 'r': {
                    accent = '3';
                    break;
                }
                case 'X': 
                case 'x': {
                    accent = '4';
                    break;
                }
                case 'J': 
                case 'j': {
                    accent = '5';
                    break;
                }
                case 'A': 
                case 'E': 
                case 'O': 
                case 'a': 
                case 'e': 
                case 'o': {
                    accent = '6';
                    break;
                }
                case 'W': 
                case 'w': {
                    accent = '7';
                    break;
                }
                case 'D': 
                case 'd': {
                    accent = '9';
                    break;
                }
                case 'Z': 
                case 'z': {
                    accent = '0';
                }
            }
            if (accent == '6' || accent == '7') {
                accent = VietKey.getAccentInTelex(this.curWord, keyChar, accent);
            }
        }
        return accent;
    }

    private String getCurrentWord(int pos, String source) {
        boundary.setText(source);
        this.end = boundary.following(pos - 1);
        this.start = boundary.previous();
        this.end = pos;
        return source.substring(this.start, this.end);
    }

    static {
        vietModeOn = true;
        boundary = BreakIterator.getWordInstance();
    }
}

