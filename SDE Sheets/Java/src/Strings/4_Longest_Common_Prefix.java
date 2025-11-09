package Strings;

class LongestCommonPrefix {
    public static void main(String[] args) {
        var arr = new String[] {"dog","racecar","car"};

        int n = arr.length;

        String commonString = arr[0];

        for(int i=1; i<n; i++) {

            if(commonString.length() == 0) {
                System.out.println(commonString);
                return;
            }

            int j=0, k=0;
            String temp = "";
            while(j<arr[i].length() && k<commonString.length() && 
                    arr[j].charAt(k) == commonString.charAt(k)) {
                temp += arr[i].charAt(j);
                j++; k++;
            }
            
            commonString = temp;
        }

        System.out.println(commonString);
    }    
}
