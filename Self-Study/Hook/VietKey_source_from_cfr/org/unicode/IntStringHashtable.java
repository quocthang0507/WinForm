/*
 * Decompiled with CFR 0.139.
 */
package org.unicode;

import java.util.Hashtable;

public class IntStringHashtable {
    static final String copyright = "Copyright (c) 1998-1999 Unicode, Inc.";
    private String defaultValue;
    private Hashtable table = new Hashtable();

    public IntStringHashtable(String defaultValue) {
        this.defaultValue = defaultValue;
    }

    public void put(int key, String value) {
        if (value == this.defaultValue) {
            this.table.remove(new Integer(key));
        } else {
            this.table.put(new Integer(key), value);
        }
    }

    public String get(int key) {
        Object value = this.table.get(new Integer(key));
        if (value == null) {
            return this.defaultValue;
        }
        return (String)value;
    }
}

