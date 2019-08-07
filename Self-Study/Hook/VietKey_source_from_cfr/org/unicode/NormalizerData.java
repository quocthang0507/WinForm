/*
 * Decompiled with CFR 0.139.
 */
package org.unicode;

import java.util.BitSet;
import org.unicode.IntHashtable;
import org.unicode.IntStringHashtable;

public class NormalizerData {
    static final String copyright = "Copyright (c) 1998-1999 Unicode, Inc.";
    public static final int NOT_COMPOSITE = 65535;
    private IntHashtable canonicalClass;
    private IntStringHashtable decompose;
    private IntHashtable compose;
    private BitSet isCompatibility = new BitSet();
    private BitSet isExcluded = new BitSet();

    public int getCanonicalClass(char ch) {
        return this.canonicalClass.get(ch);
    }

    public char getPairwiseComposition(char first, char second) {
        return (char)this.compose.get(first << 16 | second);
    }

    public void getRecursiveDecomposition(boolean canonical, char ch, StringBuffer buffer) {
        String decomp = this.decompose.get(ch);
        if (!(decomp == null || canonical && this.isCompatibility.get(ch))) {
            for (int i = 0; i < decomp.length(); ++i) {
                this.getRecursiveDecomposition(canonical, decomp.charAt(i), buffer);
            }
        } else {
            buffer.append(ch);
        }
    }

    NormalizerData(IntHashtable canonicalClass, IntStringHashtable decompose, IntHashtable compose, BitSet isCompatibility, BitSet isExcluded) {
        this.canonicalClass = canonicalClass;
        this.decompose = decompose;
        this.compose = compose;
        this.isCompatibility = isCompatibility;
        this.isExcluded = isExcluded;
    }

    boolean getExcluded(char ch) {
        return this.isExcluded.get(ch);
    }

    String getRawDecompositionMapping(char ch) {
        return this.decompose.get(ch);
    }
}

