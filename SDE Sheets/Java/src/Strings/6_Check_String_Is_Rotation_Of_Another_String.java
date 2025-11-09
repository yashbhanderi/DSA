package Strings;

class RotateString {

    public static boolean isRotated(String A, String B, int rotation) {
        for(int i = 0; i < A.length(); i++) {
           if(A.charAt(i) != B.charAt((i+rotation)%B.length())) {
               return false;
           }
       }
       return true;
   }

    public static void main(String[] args) {
        String A = "abcde", B = "cdeab";

        if(A == null || B == null) {
            //throw exception on A and B both being null?
            // return false;
        }
        if(A.length() != B.length()) {
            // return false;
        }
        if(A.length() == 0) {
            // return true;
        }
        for(int i = 0; i < A.length(); i++) {
            if(isRotated(A, B, i)) {
                // return true;
            }
        }
        // return false;
    }
}