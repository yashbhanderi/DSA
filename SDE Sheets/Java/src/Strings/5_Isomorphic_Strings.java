package Strings;

import java.util.HashMap;

class IsomorphicStrings {
    public static void main(String[] args) {
        String s = "foo", t = "bar";

        int n = s.length();

        String ans = "";

        HashMap<Character, Character> map = new HashMap<>();
        
        for(int i=0; i<n; i++) {
            char c1 = s.charAt(i), c2 = t.charAt(i);

            if(map.containsKey(c2)) {
                if(map.get(c2) != c1) {
                    System.out.println("c2");
                }
                ans += map.get(c2);
            }
            else {
                map.put(c2, c1);
                ans += c2;
            }
        }

        System.out.println(ans);
    }    
}
