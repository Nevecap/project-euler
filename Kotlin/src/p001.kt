fun main(args: Array<String>) {
    var a = 3
    var b = 5
    var N = 1000;
    var sum: Long = 0
    var cur = a;
    while(cur < N){
        sum += cur
        cur += a
    }
    cur = b;
    while(cur < N){
        if(cur % a != 0)
            sum+=cur
        cur += b
    }
    println(sum)
}