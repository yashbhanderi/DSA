package Common;

public class Pair<L,R> implements Comparable<Pair> {
    private L l;
    private R r;
    public Pair(L l, R r){
        this.l = l;
        this.r = r;
    }
    public L getL(){ return l; }
    public R getR(){ return r; }
    public void setL(L l){ this.l = l; }
    public void setR(R r){ this.r = r; }

    @Override
    public int compareTo(Pair other) {
        return Integer.compare((Integer) other.r, (Integer) this.r);
    }
}
