package assignment1;
import java.util.HashMap;
public class FinancialForecast {


	    public static double futureValueRecursive(double initial, double rate, int years) {
	        if (years == 0) {
	            return initial; 
	        }
	        return (1 + rate) * futureValueRecursive(initial, rate, years - 1);
	    }
   
	    static HashMap<Integer, Double> memo = new HashMap<>();

	    public static double futureValueMemoized(double initial, double rate, int years) {
	        if (years == 0) {
	            return initial;
	        }
	        if (memo.containsKey(years)) {
	            return memo.get(years);
	        }
	        double result = (1 + rate) * futureValueMemoized(initial, rate, years - 1);
	        memo.put(years, result);
	        return result;
	    }

	    public static void main(String[] args) {
	        double initialAmount = 10000; 
	        double growthRate = 0.05;     
	        int futureYears = 10;        

	      
	        double future = futureValueRecursive(initialAmount, growthRate, futureYears);
	        System.out.printf("Future Value using Recursion after %d years: ₹%.2f\n", futureYears, future);

	       
	        double futureOpt = futureValueMemoized(initialAmount, growthRate, futureYears);
	        System.out.printf("Future Value using Memoization after %d years: ₹%.2f\n", futureYears, futureOpt);

	      
	    }
	}
