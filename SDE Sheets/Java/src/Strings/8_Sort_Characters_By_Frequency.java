package Strings;

import Common.Pair;

import java.util.*;

class SortCharactersByFrequency {
    
    public static void main(String[] args) {
        String s = "tree";
        
        int n = s.length();

        HashMap<Character, Integer> map = new HashMap<>();
        
        for(var c: s.toCharArray()) {
            map.put(c, map.getOrDefault(c, 0) + 1);
        }
        
        var list = new ArrayList<Pair<Character, Integer>>();
        
        map.forEach((key, value) -> {
            list.add(new Pair<>(key, value));
        });

        Collections.sort(list);
    
        StringBuilder ans = new StringBuilder();
        list.forEach(item -> {
            for (Integer i = 0; i < item.getR(); i++) {
                ans.append(item.getL());
            }
        });

        System.out.println(ans);
    }
}