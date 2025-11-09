package Strings;

class LargestOddNumberInString {
    public static void main(String[] args) {
        String str = "35427";

        int n = str.length();

        for(int i=n-1; i>=0; i--) {
            String temp = "";
            temp += str.charAt(i);
            int num = Integer.parseInt(temp);
            if(num % 2 != 0) {
                System.out.println(num);
                return;
            }
        }
    }
}