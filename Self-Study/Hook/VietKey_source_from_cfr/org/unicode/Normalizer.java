/*
 * Decompiled with CFR 0.139.
 */
package org.unicode;

import org.unicode.NormalizerBuilder;
import org.unicode.NormalizerData;

public class Normalizer {
    static final String copyright = "Copyright (c) 1998-1999 Unicode, Inc.";
    static final byte COMPATIBILITY_MASK = 1;
    static final byte COMPOSITION_MASK = 2;
    public static final byte D = 0;
    public static final byte C = 2;
    public static final byte KD = 1;
    public static final byte KC = 3;
    private static Normalizer normalizer;
    private byte form;
    private static NormalizerData data;

    public Normalizer(byte form, boolean fullData) {
        this.form = form;
        if (data == null) {
            data = NormalizerBuilder.build(fullData);
        }
    }

    public StringBuffer normalize(String source, StringBuffer target) {
        if (source.length() != 0) {
            this.internalDecompose(source, target);
            if ((this.form & 2) != 0) {
                this.internalCompose(target);
            }
        }
        return target;
    }

    public String normalize(String source) {
        return this.normalize(source, new StringBuffer()).toString();
    }

    public char normalize(char source) {
        return this.normalize(String.valueOf(source)).charAt(0);
    }

    public static String compose(String str, boolean compat) {
        if (normalizer == null) {
            normalizer = new Normalizer(compat ? (byte)3 : 2, false);
        } else {
            Normalizer.normalizer.form = (byte)(compat ? 3 : 2);
        }
        return normalizer.normalize(str);
    }

    public static String decompose(String str, boolean compat) {
        if (normalizer == null) {
            normalizer = new Normalizer(compat ? (byte)1 : 0, false);
        } else {
            Normalizer.normalizer.form = compat ? (byte)1 : 0;
        }
        return normalizer.normalize(str);
    }

    private void internalDecompose(String source, StringBuffer target) {
        StringBuffer buffer = new StringBuffer();
        boolean canonical = (this.form & 1) == 0;
        for (int i = 0; i < source.length(); ++i) {
            buffer.setLength(0);
            data.getRecursiveDecomposition(canonical, source.charAt(i), buffer);
            for (int j = 0; j < buffer.length(); ++j) {
                int k;
                char ch = buffer.charAt(j);
                int chClass = data.getCanonicalClass(ch);
                if (chClass != 0) {
                    for (k = target.length(); k > 0 && data.getCanonicalClass(target.charAt(k - 1)) > chClass; --k) {
                    }
                }
                target.insert(k, ch);
            }
        }
    }

    private void internalCompose(StringBuffer target) {
        int starterPos = 0;
        int compPos = 1;
        char starterCh = target.charAt(0);
        int lastClass = data.getCanonicalClass(starterCh);
        if (lastClass != 0) {
            lastClass = 256;
        }
        for (int decompPos = 1; decompPos < target.length(); ++decompPos) {
            char ch = target.charAt(decompPos);
            int chClass = data.getCanonicalClass(ch);
            char composite = data.getPairwiseComposition(starterCh, ch);
            if (composite != '\uffff' && (lastClass < chClass || lastClass == 0)) {
                target.setCharAt(starterPos, composite);
                starterCh = composite;
                continue;
            }
            if (chClass == 0) {
                starterPos = compPos;
                starterCh = ch;
            }
            lastClass = chClass;
            target.setCharAt(compPos++, ch);
        }
        target.setLength(compPos);
    }

    boolean getExcluded(char ch) {
        return data.getExcluded(ch);
    }

    String getRawDecompositionMapping(char ch) {
        return data.getRawDecompositionMapping(ch);
    }

    static {
        data = null;
    }
}

