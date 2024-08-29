package Strings;

class ReverseWordsInAString {
    public static void main(String[] args) {
        String str = "a good   example";
        String ans = "";

        int n = str.length();

        int i=n-1;
        while(i>=0) {

            while(i>=0 && str.charAt(i)==' ') {
                i--;
                continue;
            }
            
            int j=i;
            String temp = "";

            while(j>=0 && str.charAt(j)!=' ') {
                temp += str.charAt(j);
                j--;
            }

            for(int k=temp.length()-1; k>=0; k--) {
                ans += temp.charAt(k);
            }

            ans += " ";
            i=j-1;
        }

        System.out.println(ans.trim());
    }
}
