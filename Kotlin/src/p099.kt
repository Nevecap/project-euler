import kotlin.math.E
import kotlin.math.log

fun main(args: Array<String>) {
    var filename = "../Problems/p099_base_exp.txt"
    //Считываем весь файл
    var file = readFileLineByLineUsingForEachLine(filename)
    var numbers = mutableListOf<basePow>()
    var len = file.size
    //Переносим строки в пары целых чисел
    for(snumber in file){
        var snumbers = snumber.split(',')
        var a = snumbers[0].toInt()
        var b = snumbers[1].toInt()
        numbers.add(basePow(a, b))
    }
    //for(number in numbers){
    //    println(number.base.toString() + ", " + number.pow)
    //}
    var strNumber = 0
    var max = 0.0
    var count = 0
    //В цикле ищем максимум
    for(number in numbers){
        //Умножить степень числа на логарифм числа по основанию e
        var cur = number.pow * log(number.base.toDouble(), E)
        if(cur > max){
            strNumber = count
            max = cur
        }
        count++
    }
    println(strNumber + 1)
}
class basePow(base: Int, pow: Int){
    var base: Int = base
    var pow: Int = pow
}