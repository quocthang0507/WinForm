/*
 * Decompiled with CFR 0.139.
 */
package org.unicode;

import java.util.BitSet;
import org.unicode.IntHashtable;
import org.unicode.IntStringHashtable;
import org.unicode.NormalizerData;

class NormalizerBuilder {
    static final String copyright = "Copyright (c) 1998-1999 Unicode, Inc.";

    NormalizerBuilder() {
    }

    static NormalizerData build(boolean fullData) {
        IntHashtable canonicalClass = new IntHashtable(0);
        IntStringHashtable decompose = new IntStringHashtable(null);
        IntHashtable compose = new IntHashtable(65535);
        BitSet isCompatibility = new BitSet();
        BitSet isExcluded = new BitSet();
        NormalizerBuilder.setMinimalDecomp(canonicalClass, decompose, compose, isCompatibility, isExcluded);
        return new NormalizerData(canonicalClass, decompose, compose, isCompatibility, isExcluded);
    }

    private static void setMinimalDecomp(IntHashtable canonicalClass, IntStringHashtable decompose, IntHashtable compose, BitSet isCompatibility, BitSet isExcluded) {
        int i;
        String[] decomposeData = new String[]{"^", " \u0302", "K", "_", " \u0332", "K", "`", " \u0300", "K", "\u00a0", " ", "K", "\u00a8", " \u0308", "K", "\u00aa", "a", "K", "\u00af", " \u0304", "K", "\u00b2", "2", "K", "\u00b3", "3", "K", "\u00b4", " \u0301", "K", "\u00b5", "\u03bc", "K", "\u00b8", " \u0327", "K", "\u00b9", "1", "K", "\u00ba", "o", "K", "\u00bc", "1\u20444", "K", "\u00bd", "1\u20442", "K", "\u00be", "3\u20444", "K", "\u00c0", "A\u0300", "", "\u00c1", "A\u0301", "", "\u00c2", "A\u0302", "", "\u00c3", "A\u0303", "", "\u00c4", "A\u0308", "", "\u00c5", "A\u030a", "", "\u00c7", "C\u0327", "", "\u00c8", "E\u0300", "", "\u00c9", "E\u0301", "", "\u00ca", "E\u0302", "", "\u00cb", "E\u0308", "", "\u00cc", "I\u0300", "", "\u00cd", "I\u0301", "", "\u00ce", "I\u0302", "", "\u00cf", "I\u0308", "", "\u00d1", "N\u0303", "", "\u00d2", "O\u0300", "", "\u00d3", "O\u0301", "", "\u00d4", "O\u0302", "", "\u00d5", "O\u0303", "", "\u00d6", "O\u0308", "", "\u00d9", "U\u0300", "", "\u00da", "U\u0301", "", "\u00db", "U\u0302", "", "\u00dc", "U\u0308", "", "\u00dd", "Y\u0301", "", "\u00e0", "a\u0300", "", "\u00e1", "a\u0301", "", "\u00e2", "a\u0302", "", "\u00e3", "a\u0303", "", "\u00e4", "a\u0308", "", "\u00e5", "a\u030a", "", "\u00e7", "c\u0327", "", "\u00e8", "e\u0300", "", "\u00e9", "e\u0301", "", "\u00ea", "e\u0302", "", "\u00eb", "e\u0308", "", "\u00ec", "i\u0300", "", "\u00ed", "i\u0301", "", "\u00ee", "i\u0302", "", "\u00ef", "i\u0308", "", "\u00f1", "n\u0303", "", "\u00f2", "o\u0300", "", "\u00f3", "o\u0301", "", "\u00f4", "o\u0302", "", "\u00f5", "o\u0303", "", "\u00f6", "o\u0308", "", "\u00f9", "u\u0300", "", "\u00fa", "u\u0301", "", "\u00fb", "u\u0302", "", "\u00fc", "u\u0308", "", "\u00fd", "y\u0301", "", "\u0102", "A\u0306", "", "\u0103", "a\u0306", "", "\u0128", "I\u0303", "", "\u0129", "i\u0303", "", "\u0168", "U\u0303", "", "\u0169", "u\u0303", "", "\u01a0", "O\u031b", "", "\u01a1", "o\u031b", "", "\u01af", "U\u031b", "", "\u01b0", "u\u031b", "", "\u1ea0", "A\u0323", "", "\u1ea1", "a\u0323", "", "\u1ea2", "A\u0309", "", "\u1ea3", "a\u0309", "", "\u1ea4", "\u00c2\u0301", "", "\u1ea5", "\u00e2\u0301", "", "\u1ea6", "\u00c2\u0300", "", "\u1ea7", "\u00e2\u0300", "", "\u1ea8", "\u00c2\u0309", "", "\u1ea9", "\u00e2\u0309", "", "\u1eaa", "\u00c2\u0303", "", "\u1eab", "\u00e2\u0303", "", "\u1eac", "\u1ea0\u0302", "", "\u1ead", "\u1ea1\u0302", "", "\u1eae", "\u0102\u0301", "", "\u1eaf", "\u0103\u0301", "", "\u1eb0", "\u0102\u0300", "", "\u1eb1", "\u0103\u0300", "", "\u1eb2", "\u0102\u0309", "", "\u1eb3", "\u0103\u0309", "", "\u1eb4", "\u0102\u0303", "", "\u1eb5", "\u0103\u0303", "", "\u1eb6", "\u1ea0\u0306", "", "\u1eb7", "\u1ea1\u0306", "", "\u1eb8", "E\u0323", "", "\u1eb9", "e\u0323", "", "\u1eba", "E\u0309", "", "\u1ebb", "e\u0309", "", "\u1ebc", "E\u0303", "", "\u1ebd", "e\u0303", "", "\u1ebe", "\u00ca\u0301", "", "\u1ebf", "\u00ea\u0301", "", "\u1ec0", "\u00ca\u0300", "", "\u1ec1", "\u00ea\u0300", "", "\u1ec2", "\u00ca\u0309", "", "\u1ec3", "\u00ea\u0309", "", "\u1ec4", "\u00ca\u0303", "", "\u1ec5", "\u00ea\u0303", "", "\u1ec6", "\u1eb8\u0302", "", "\u1ec7", "\u1eb9\u0302", "", "\u1ec8", "I\u0309", "", "\u1ec9", "i\u0309", "", "\u1eca", "I\u0323", "", "\u1ecb", "i\u0323", "", "\u1ecc", "O\u0323", "", "\u1ecd", "o\u0323", "", "\u1ece", "O\u0309", "", "\u1ecf", "o\u0309", "", "\u1ed0", "\u00d4\u0301", "", "\u1ed1", "\u00f4\u0301", "", "\u1ed2", "\u00d4\u0300", "", "\u1ed3", "\u00f4\u0300", "", "\u1ed4", "\u00d4\u0309", "", "\u1ed5", "\u00f4\u0309", "", "\u1ed6", "\u00d4\u0303", "", "\u1ed7", "\u00f4\u0303", "", "\u1ed8", "\u1ecc\u0302", "", "\u1ed9", "\u1ecd\u0302", "", "\u1eda", "\u01a0\u0301", "", "\u1edb", "\u01a1\u0301", "", "\u1edc", "\u01a0\u0300", "", "\u1edd", "\u01a1\u0300", "", "\u1ede", "\u01a0\u0309", "", "\u1edf", "\u01a1\u0309", "", "\u1ee0", "\u01a0\u0303", "", "\u1ee1", "\u01a1\u0303", "", "\u1ee2", "\u01a0\u0323", "", "\u1ee3", "\u01a1\u0323", "", "\u1ee4", "U\u0323", "", "\u1ee5", "u\u0323", "", "\u1ee6", "U\u0309", "", "\u1ee7", "u\u0309", "", "\u1ee8", "\u01af\u0301", "", "\u1ee9", "\u01b0\u0301", "", "\u1eea", "\u01af\u0300", "", "\u1eeb", "\u01b0\u0300", "", "\u1eec", "\u01af\u0309", "", "\u1eed", "\u01b0\u0309", "", "\u1eee", "\u01af\u0303", "", "\u1eef", "\u01b0\u0303", "", "\u1ef0", "\u01af\u0323", "", "\u1ef1", "\u01b0\u0323", "", "\u1ef2", "Y\u0300", "", "\u1ef3", "y\u0300", "", "\u1ef4", "Y\u0323", "", "\u1ef5", "y\u0323", "", "\u1ef6", "Y\u0309", "", "\u1ef7", "y\u0309", "", "\u1ef8", "Y\u0303", "", "\u1ef9", "y\u0303", ""};
        int[] classData = new int[]{768, 230, 769, 230, 770, 230, 771, 230, 772, 230, 773, 230, 774, 230, 775, 230, 776, 230, 777, 230, 778, 230, 779, 230, 780, 230, 781, 230, 782, 230, 783, 230, 784, 230, 785, 230, 786, 230, 787, 230, 788, 230, 789, 232, 790, 220, 791, 220, 792, 220, 793, 220, 794, 232, 795, 216, 796, 220, 797, 220, 798, 220, 799, 220, 800, 220, 801, 202, 802, 202, 803, 220, 804, 220, 805, 220, 806, 220, 807, 202, 808, 202, 809, 220, 810, 220, 811, 220, 812, 220, 813, 220, 814, 220, 815, 220, 816, 220, 817, 220, 818, 220, 819, 220, 820, 1, 821, 1, 822, 1, 823, 1, 824, 1, 825, 220, 826, 220, 827, 220, 828, 220, 829, 230, 830, 230, 831, 230, 832, 230, 833, 230, 834, 230, 835, 230, 836, 230, 837, 240, 864, 234, 865, 234};
        for (i = 0; i < decomposeData.length; i += 3) {
            char value = decomposeData[i].charAt(0);
            String decomp = decomposeData[i + 1];
            boolean compat = decomposeData[i + 2].equals("K");
            if (compat) {
                isCompatibility.set(value);
            }
            decompose.put(value, decomp);
            if (compat) continue;
            char first = '\u0000';
            char second = decomp.charAt(0);
            if (decomp.length() > 1) {
                first = second;
                second = decomp.charAt(1);
            }
            int pair = first << 16 | second;
            compose.put(pair, value);
        }
        i = 0;
        while (i < classData.length) {
            canonicalClass.put(classData[i++], classData[i++]);
        }
    }
}

