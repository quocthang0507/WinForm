/*
 * Decompiled with CFR 0.139.
 */
package org.unicode;

import java.util.Hashtable;

public class IntHashtable {
    static final String copyright = "Copyright (c) 1998-1999 Unicode, Inc.";
    private int defaultValue;
    private Hashtable table = new Hashtable();

    public IntHashtable(int defaultValue) {
        this.defaultValue = defaultValue;
    }

    public void put(int key, int value) {
        if (value == this.defaultValue) {
            this.table.remove(new Integer(key));
        } else {
            this.table.put(new Integer(key), new Integer(value));
        }
    }

    public int get(int key) {
        Object value = this.table.get(new Integer(key));
        if (value == null) {
            return this.defaultValue;
        }
        return (Integer)value;
    }
}

