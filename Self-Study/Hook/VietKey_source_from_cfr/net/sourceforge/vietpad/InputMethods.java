/*
 * Decompiled with CFR 0.139.
 */
package net.sourceforge.vietpad;

public class InputMethods {
    private final String method;
    public static final InputMethods VNI = new InputMethods("VNI");
    public static final InputMethods VIQR = new InputMethods("VIQR");
    public static final InputMethods Telex = new InputMethods("Telex");

    public String toString() {
        return this.method;
    }

    public static InputMethods valueOf(String method) {
        if (method.equals("VNI")) {
            return VNI;
        }
        if (method.equals("VIQR")) {
            return VIQR;
        }
        return Telex;
    }

    private InputMethods(String method) {
        this.method = method;
    }
}

