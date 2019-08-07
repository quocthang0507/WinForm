/*
 * Decompiled with CFR 0.139.
 */
package net.sourceforge.vietpad;

import java.util.regex.Matcher;
import java.util.regex.Pattern;
import org.unicode.Normalizer;

public class VietKey {
    private static final char[][] UNI_DATA = new char[][]{{'\u00e2', 'a', '\u0103', '\u00ea', 'e', 'i', '\u00f4', 'o', '\u01a1', 'u', '\u01b0', 'y', '\u00c2', 'A', '\u0102', '\u00ca', 'E', 'I', '\u00d4', 'O', '\u01a0', 'U', '\u01af', 'Y', 'd', 'D'}, {'\u1ea5', '\u00e1', '\u1eaf', '\u1ebf', '\u00e9', '\u00ed', '\u1ed1', '\u00f3', '\u1edb', '\u00fa', '\u1ee9', '\u00fd', '\u1ea4', '\u00c1', '\u1eae', '\u1ebe', '\u00c9', '\u00cd', '\u1ed0', '\u00d3', '\u1eda', '\u00da', '\u1ee8', '\u00dd', '\u0111', '\u0110'}, {'\u1ea7', '\u00e0', '\u1eb1', '\u1ec1', '\u00e8', '\u00ec', '\u1ed3', '\u00f2', '\u1edd', '\u00f9', '\u1eeb', '\u1ef3', '\u1ea6', '\u00c0', '\u1eb0', '\u1ec0', '\u00c8', '\u00cc', '\u1ed2', '\u00d2', '\u1edc', '\u00d9', '\u1eea', '\u1ef2'}, {'\u1ea9', '\u1ea3', '\u1eb3', '\u1ec3', '\u1ebb', '\u1ec9', '\u1ed5', '\u1ecf', '\u1edf', '\u1ee7', '\u1eed', '\u1ef7', '\u1ea8', '\u1ea2', '\u1eb2', '\u1ec2', '\u1eba', '\u1ec8', '\u1ed4', '\u1ece', '\u1ede', '\u1ee6', '\u1eec', '\u1ef6'}, {'\u1eab', '\u00e3', '\u1eb5', '\u1ec5', '\u1ebd', '\u0129', '\u1ed7', '\u00f5', '\u1ee1', '\u0169', '\u1eef', '\u1ef9', '\u1eaa', '\u00c3', '\u1eb4', '\u1ec4', '\u1ebc', '\u0128', '\u1ed6', '\u00d5', '\u1ee0', '\u0168', '\u1eee', '\u1ef8'}, {'\u1ead', '\u1ea1', '\u1eb7', '\u1ec7', '\u1eb9', '\u1ecb', '\u1ed9', '\u1ecd', '\u1ee3', '\u1ee5', '\u1ef1', '\u1ef5', '\u1eac', '\u1ea0', '\u1eb6', '\u1ec6', '\u1eb8', '\u1eca', '\u1ed8', '\u1ecc', '\u1ee2', '\u1ee4', '\u1ef0', '\u1ef4'}};
    private static final char ddc = '\u0110';
    private static final char DDc = '\u0111';
    private static final char uMoc = '\u01b0';
    private static final char UMoc = '\u01af';
    private static final char oMoc = '\u01a1';
    private static final String CMNPT = "cmnpt";
    private static final String DDDD = "Dd\u0110\u0111";
    private static final String EIOUY = "eiouy";
    private static final String AEOY = "aeoy";
    private static boolean accentRemoved;
    private static boolean diacriticsPosClassicOn;
    private static final Pattern vowelpat2;
    private static final Pattern xconso;
    private static final Pattern vconso2;
    private static final Pattern alpha;
    private static final Pattern dblconso;
    private static final Pattern endDoubleVowels;
    private static Normalizer decomposer;

    private VietKey() {
    }

    private static char composeVowel(int j, int acc, int i) {
        char composedvowel;
        if (acc < 6) {
            composedvowel = UNI_DATA[acc][j];
        } else if (acc == 9 && j > 23) {
            composedvowel = UNI_DATA[1][j];
        } else {
            int newpos = j;
            if (acc == 6) {
                int n = j == 1 || j == 4 || j == 7 || j == 13 || j == 16 || j == 19 ? j - 1 : (newpos = j == 2 || j == 8 || j == 14 || j == 20 ? j - 2 : j);
            }
            if (acc == 7) {
                int n = j == 7 || j == 9 || j == 19 || j == 21 ? (newpos = j + 1) : (newpos = j == 6 || j == 18 ? j + 2 : j);
            }
            if (acc == 8) {
                newpos = j == 1 || j == 13 ? j + 1 : (j == 0 || j == 12 ? j + 2 : j);
            }
            composedvowel = UNI_DATA[i][newpos];
        }
        return composedvowel;
    }

    private static char removeAccent(int j, int acc, int i) {
        char resultVal;
        if (acc < 6) {
            resultVal = UNI_DATA[0][j];
        } else if (acc == 9 && j > 23) {
            resultVal = UNI_DATA[0][j];
        } else {
            int newPos = j;
            newPos = acc == 6 && (j == 0 || j == 3 || j == 6 || j == 12 || j == 15 || j == 18) ? j + 1 : (acc == 7 && (j == 8 || j == 10 || j == 20 || j == 22) ? j - 1 : (acc == 8 && (j == 2 || j == 14) ? j - 1 : j));
            resultVal = UNI_DATA[i][newPos];
        }
        return resultVal;
    }

    public static char toVietChar(char curChar, char accentKey) {
        return VietKey.toVietChar(curChar, accentKey - 48);
    }

    public static char toVietChar(char curChar, int accentIndex) {
        accentRemoved = false;
        for (int i = 0; i < UNI_DATA.length; ++i) {
            for (int j = 0; j < UNI_DATA[i].length; ++j) {
                if (UNI_DATA[i][j] != curChar) continue;
                if (DDDD.indexOf(curChar) != -1 && accentIndex != 0 && accentIndex != 9) {
                    return curChar;
                }
                char vietChar = VietKey.composeVowel(j, accentIndex, i);
                if (vietChar == curChar) {
                    if (accentIndex != 0) {
                        accentRemoved = true;
                    }
                    if ((vietChar = VietKey.removeAccent(j, accentIndex, i)) == curChar && accentIndex == 0) {
                        vietChar = decomposer.normalize(curChar);
                    }
                }
                return vietChar;
            }
        }
        return curChar;
    }

    public static String toVietWord(String curWord, char accentKey) {
        return VietKey.toVietWord(curWord, accentKey - 48);
    }

    public static String toVietWord(String curWord, int accentIndex) {
        int wl = curWord.length();
        char[] cp = curWord.toCharArray();
        String wordNew = null;
        String lowCase = curWord.toLowerCase();
        if (accentIndex == 9 && DDDD.indexOf(cp[0]) != -1) {
            cp[0] = VietKey.toVietChar(curWord.charAt(0), accentIndex);
            wordNew = String.valueOf(cp);
            return wordNew;
        }
        if (wl < 8 && Character.isLetterOrDigit(cp[wl - 1])) {
            if (wl > 2 && dblconso.matcher(curWord.substring(wl - 2)).lookingAt()) {
                if (wl > 3) {
                    VietKey.fix_uo(4, wl, accentIndex, cp);
                    wordNew = curWord.substring(0, wl - 4) + cp[wl - 4] + cp[wl - 3] + cp[wl - 2] + cp[wl - 1];
                } else if (wl == 3) {
                    wordNew = "" + VietKey.toVietChar(cp[0], accentIndex) + cp[wl - 2] + cp[wl - 1];
                }
            } else if (!(wl < 3 || CMNPT.indexOf(Character.toLowerCase(curWord.charAt(wl - 1))) < 0 && (lowCase.charAt(wl - 1) != 'i' && lowCase.charAt(wl - 1) != 'u' || lowCase.charAt(wl - 3) != 'u' && lowCase.charAt(wl - 3) != '\u01b0'))) {
                VietKey.fix_uo(3, wl, accentIndex, cp);
                wordNew = curWord.substring(0, wl - 3) + cp[wl - 3] + cp[wl - 2] + cp[wl - 1];
            } else if (wl == 3 && (lowCase.startsWith("qu") || lowCase.startsWith("gi"))) {
                wordNew = curWord.substring(0, wl - 1) + VietKey.toVietChar(cp[wl - 1], accentIndex);
            } else if (wl > 1 && accentIndex == 6 && (Character.toLowerCase(decomposer.normalize(cp[wl - 2])) == 'u' || Character.toLowerCase(decomposer.normalize(cp[wl - 2])) == 'i' || Character.toLowerCase(decomposer.normalize(cp[wl - 2])) == 'y')) {
                wordNew = VietKey.shiftAccent(curWord, (char)(accentIndex + 48));
                cp = wordNew.toCharArray();
                wordNew = wordNew.substring(0, wl - 2) + cp[wl - 2] + VietKey.toVietChar(cp[wl - 1], accentIndex);
            }
            if (wordNew != null) {
                if (accentIndex == 0 && wordNew.equals(curWord)) {
                    wordNew = decomposer.normalize(curWord).replace('\u0111', 'd').replace('\u0110', 'D');
                }
                return wordNew;
            }
            if (wl > 1) {
                for (int i = 0; i < UNI_DATA.length; ++i) {
                    if (cp[wl - 2] != UNI_DATA[i][10] && cp[wl - 2] != UNI_DATA[i][22] && cp[wl - 2] != UNI_DATA[i][9] && cp[wl - 2] != UNI_DATA[i][21] || Character.toLowerCase(cp[wl - 1]) != 'o') continue;
                    cp[wl - 1] = VietKey.toVietChar(cp[wl - 1], accentIndex);
                    if (i != 0) {
                        cp[wl - 1] = VietKey.toVietChar(cp[wl - 1], i);
                        accentRemoved = false;
                    }
                    return curWord.substring(0, wl - 2) + cp[wl - 2] + cp[wl - 1];
                }
            }
            if (wl > 1 && cp[wl - 2] != '\u0110' && cp[wl - 2] != '\u0111' && !vconso2.matcher(String.valueOf(cp[wl - 2])).lookingAt() && alpha.matcher("" + cp[wl - 1]).lookingAt()) {
                if (wl > 2 && accentIndex == 7 && Character.toLowerCase(cp[wl - 3]) == 'u') {
                    wordNew = curWord.substring(0, wl - 3) + VietKey.toVietChar(cp[wl - 3], accentIndex) + VietKey.toVietChar(cp[wl - 2], accentIndex) + cp[wl - 1];
                } else if (wl > 2 && accentIndex == 6 && Character.toLowerCase(decomposer.normalize(cp[wl - 3])) == 'u') {
                    if (cp[wl - 3] == '\u01b0') {
                        cp[wl - 3] = 117;
                    }
                    if (cp[wl - 3] == '\u01af') {
                        cp[wl - 3] = 85;
                    }
                    wordNew = curWord.substring(0, wl - 3) + cp[wl - 3] + VietKey.toVietChar(cp[wl - 2], accentIndex) + cp[wl - 1];
                } else if ((accentIndex == 6 || accentIndex == 7) && vowelpat2.matcher(String.valueOf(cp[wl - 2])).lookingAt()) {
                    wordNew = curWord.substring(0, wl - 1) + VietKey.toVietChar(cp[wl - 1], accentIndex);
                } else if (accentIndex == 8 && !vconso2.matcher(String.valueOf(cp[wl - 1])).lookingAt()) {
                    if (Character.toLowerCase(decomposer.normalize(cp[wl - 2])) == 'i' || Character.toLowerCase(decomposer.normalize(cp[wl - 2])) == 'u' || Character.toLowerCase(decomposer.normalize(cp[wl - 2])) == 'o') {
                        wordNew = VietKey.shiftAccent(curWord, (char)(accentIndex + 48));
                        cp = wordNew.toCharArray();
                    } else {
                        wordNew = curWord;
                    }
                    wordNew = wordNew.substring(0, wl - 1) + VietKey.toVietChar(cp[wl - 1], accentIndex);
                } else if (wl > 2) {
                    String temp = decomposer.normalize(curWord).replaceAll("\\p{InCombiningDiacriticalMarks}+", "");
                    if (wl > 3) {
                        wordNew = diacriticsPosClassicOn || !endDoubleVowels.matcher(temp).lookingAt() ? curWord.substring(0, wl - 3) + VietKey.toVietChar(cp[wl - 3], 0) + VietKey.toVietChar(cp[wl - 2], accentIndex) + cp[wl - 1] : curWord.substring(0, wl - 3) + VietKey.toVietChar(cp[wl - 3], 0) + cp[wl - 2] + VietKey.toVietChar(cp[wl - 1], accentIndex);
                    } else {
                        char tp;
                        char c = tp = DDDD.indexOf(cp[0]) != -1 ? cp[wl - 3] : VietKey.toVietChar(cp[wl - 3], 0);
                        wordNew = diacriticsPosClassicOn || !endDoubleVowels.matcher(temp).lookingAt() ? curWord.substring(0, wl - 3) + tp + VietKey.toVietChar(cp[wl - 2], accentIndex) + cp[wl - 1] : curWord.substring(0, wl - 3) + tp + cp[wl - 2] + VietKey.toVietChar(cp[wl - 1], accentIndex);
                    }
                } else {
                    String temp = decomposer.normalize(curWord).replaceAll("\\p{InCombiningDiacriticalMarks}+", "");
                    wordNew = diacriticsPosClassicOn || !endDoubleVowels.matcher(temp).lookingAt() ? curWord.substring(0, wl - 2) + VietKey.toVietChar(cp[wl - 2], accentIndex) + cp[wl - 1] : curWord.substring(0, wl - 1) + VietKey.toVietChar(cp[wl - 1], accentIndex);
                }
            } else if (!xconso.matcher(String.valueOf(cp[wl - 1])).lookingAt()) {
                wordNew = curWord.substring(0, wl - 1) + VietKey.toVietChar(cp[wl - 1], accentIndex);
            }
            if (wordNew != null) {
                if (accentIndex == 0 && wordNew.equals(curWord)) {
                    wordNew = decomposer.normalize(curWord).replace('\u0111', 'd').replace('\u0110', 'D');
                }
                return wordNew;
            }
        }
        return curWord;
    }

    private static void fix_uo(int x, int wl, int accentIndex, char[] cp) {
        if (accentIndex == 7 && Character.toLowerCase(decomposer.normalize(cp[wl - x])) == 'u') {
            cp[wl - x + 1] = VietKey.toVietChar(cp[wl - x + 1], accentIndex);
            cp[wl - x] = VietKey.toVietChar(cp[wl - x], accentIndex);
            for (int i = 0; i < UNI_DATA.length; ++i) {
                if (cp[wl - x + 1] == UNI_DATA[i][7] || cp[wl - x + 1] == UNI_DATA[i][19]) {
                    if (cp[wl - x] != '\u01b0' && cp[wl - x] != '\u01af') continue;
                    cp[wl - x + 1] = VietKey.toVietChar(cp[wl - x + 1], accentIndex);
                    accentRemoved = false;
                } else {
                    if (cp[wl - x + 1] != UNI_DATA[i][8] && cp[wl - x + 1] != UNI_DATA[i][20] || Character.toLowerCase(cp[wl - x]) != 'u') continue;
                    cp[wl - x] = VietKey.toVietChar(cp[wl - x], accentIndex);
                    accentRemoved = false;
                }
                break;
            }
        } else if (accentIndex == 6) {
            cp[wl - x + 1] = VietKey.toVietChar(cp[wl - x + 1], 6);
            if (cp[wl - x] == '\u01b0' || cp[wl - x] == '\u01af') {
                cp[wl - x] = VietKey.toVietChar(cp[wl - x], 7);
                accentRemoved = false;
            }
        } else {
            if (accentIndex == 0 && (Character.toLowerCase(cp[wl - x + 1]) == '\u01a1' || Character.toLowerCase(cp[wl - x + 1]) == 'o')) {
                cp[wl - x] = VietKey.toVietChar(cp[wl - x], accentIndex);
            }
            cp[wl - x + 1] = VietKey.toVietChar(cp[wl - x + 1], accentIndex);
        }
    }

    public static String shiftAccent(String curWord, char key) {
        String newWord;
        block4 : {
            char[] cp;
            char ch2;
            int wl;
            char ch1;
            block6 : {
                block5 : {
                    cp = curWord.toCharArray();
                    wl = cp.length;
                    newWord = curWord;
                    ch1 = Character.toLowerCase(cp[wl - 1]);
                    ch2 = Character.toLowerCase(cp[wl - 2]);
                    if (curWord.length() != 3 || !decomposer.normalize(curWord).toLowerCase().startsWith("qu") && !decomposer.normalize(curWord).toLowerCase().startsWith("gi")) break block5;
                    for (int i = 1; i < UNI_DATA.length; ++i) {
                        if (ch2 != UNI_DATA[i][5] && ch2 != UNI_DATA[i][9]) continue;
                        newWord = curWord.substring(0, wl - 2) + VietKey.toVietChar(cp[wl - 2], 0) + VietKey.toVietChar(cp[wl - 1], i);
                        break block4;
                    }
                    break block4;
                }
                if (EIOUY.indexOf(Character.toLowerCase(key)) == -1) break block6;
                if (ch1 != 'a' && ch1 != 'o' && ch1 != '\u01a1' && Character.toLowerCase(key) != 'e' && Character.toLowerCase(key) != 'u' && (ch1 != 'e' || Character.toLowerCase(key) != 'o')) break block4;
                for (int i = 1; i < UNI_DATA.length; ++i) {
                    if (ch2 != UNI_DATA[i][5] && ch2 != UNI_DATA[i][7] && ch2 != UNI_DATA[i][9] && ch2 != UNI_DATA[i][10] && ch2 != UNI_DATA[i][11]) continue;
                    newWord = curWord.substring(0, wl - 2) + VietKey.toVietChar(cp[wl - 2], 0) + VietKey.toVietChar(cp[wl - 1], i);
                    break block4;
                }
                break block4;
            }
            if ((CMNPT.indexOf(key) != -1 || key == '6' || key == '8') && AEOY.indexOf(ch1) != -1) {
                for (int i = 1; i < UNI_DATA.length; ++i) {
                    if (ch2 != UNI_DATA[i][5] && ch2 != UNI_DATA[i][7] && ch2 != UNI_DATA[i][9] && ch2 != UNI_DATA[i][11]) continue;
                    newWord = curWord.substring(0, wl - 2) + VietKey.toVietChar(cp[wl - 2], 0) + VietKey.toVietChar(cp[wl - 1], i);
                    break;
                }
            }
        }
        return newWord;
    }

    public static char getAccentInTelex(String curWord, char key, char accent) {
        if (accent == '6') {
            accent = '\u0000';
        }
        block0 : for (int i = 0; i < curWord.length(); ++i) {
            char tmp = curWord.charAt(i);
            for (int j = 0; j < UNI_DATA.length; ++j) {
                int k;
                if (accent == '7' || Character.toLowerCase(key) == 'a') {
                    for (k = 0; k < 3; ++k) {
                        if (tmp != UNI_DATA[j][k] && tmp != UNI_DATA[j][k + 12]) continue;
                        accent = (char)(accent == '7' ? 56 : 54);
                        break block0;
                    }
                    continue;
                }
                if (Character.toLowerCase(key) == 'o') {
                    for (k = 6; k < 9; ++k) {
                        if (tmp != UNI_DATA[j][k] && tmp != UNI_DATA[j][k + 12]) continue;
                        accent = (char)54;
                        break block0;
                    }
                    continue;
                }
                for (k = 3; k < 5; ++k) {
                    if (tmp != UNI_DATA[j][k] && tmp != UNI_DATA[j][k + 12]) continue;
                    accent = (char)54;
                    break block0;
                }
            }
        }
        return accent;
    }

    public static boolean isAccentRemoved() {
        return accentRemoved;
    }

    public static void setDiacriticsPosClassic(boolean classic) {
        diacriticsPosClassicOn = classic;
    }

    static {
        vowelpat2 = Pattern.compile("[iy]", 2);
        xconso = Pattern.compile("[bcfghjklmnpqrstvwxz0-9]", 2);
        vconso2 = Pattern.compile("[bcdfghjklmnpqrstvwxyz0-9]", 2);
        alpha = Pattern.compile("[a-z]", 2);
        dblconso = Pattern.compile(".h$|.g$", 2);
        endDoubleVowels = Pattern.compile(".*oa$|.*oe$|.*uy$", 2);
        decomposer = new Normalizer(0, false);
    }
}

