package Strings;

import java.util.ArrayList;

class Remove_Outermost_Parentheses {
    public static void main(String[] args) {
        String s = "(()())(())(()(()))";

        int n = s.length();

        int openBrackets = 0;
        int closeBrackets = 0;
        int startIndex = 0;
        var index = new ArrayList<Integer>();
        String ans = "";

        int i=0;
        while(i<n) {
            char c = s.charAt(i);
            
            if (c == '(') {
                openBrackets++;
            } 
            else if (c == ')') {
                closeBrackets++;
            }
            
            if(openBrackets == closeBrackets) {
                index.add(startIndex);
                index.add(i);
                openBrackets = 0;
                closeBrackets = 0;
                startIndex = i+1;
            }
            
            i++;
        }
        
        for(int k=0; k<n; k++) {
            if(!index.contains(k)) ans+=s.charAt(k);
        }

        System.out.println(ans);
    }
}
