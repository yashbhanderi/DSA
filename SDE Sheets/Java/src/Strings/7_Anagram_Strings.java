package Strings;

import java.util.HashMap;

class AnagramStrings {
    public static void main(String[] args) {
        
        String s = "anagram", t = "nagaram";
        
        HashMap<Character, Integer> charCountMap = new HashMap<>();

        // Count character occurrences in both strings
        for (char c : s.toCharArray()) {
            charCountMap.put(c, charCountMap.getOrDefault(c, 0) + 1);
        }
        for (char c : t.toCharArray()) {
            charCountMap.put(c, charCountMap.getOrDefault(c, 0) - 1);
        }

        // Check if all counts are zero (meaning equal occurrences)
        for (var entry : charCountMap.entrySet()) {
            if (entry.getValue() != 0) {
                System.out.println("False");
                return;
            }
        }

        System.out.println("True");
    }
}
