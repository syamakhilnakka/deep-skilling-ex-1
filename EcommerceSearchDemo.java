package assignment1;
import java.util.Arrays;
import java.util.Comparator;

public class EcommerceSearchDemo {

	    static class Product {
	        int productId;
	        String productName;
	        String category;

	        public Product(int productId, String productName, String category) {
	            this.productId = productId;
	            this.productName = productName;
	            this.category = category;
	        }

	     
	        public String toString() {
	            return productId + " - " + productName + " (" + category + ")";
	        }
	    }

	  
	    public static Product linearSearch(Product[] products, String targetName) {
	        for (Product product : products) {
	            if (product.productName.equalsIgnoreCase(targetName)) {
	                return product;
	            }
	        }
	        return null;
	    }

	    public static Product binarySearch(Product[] products, String targetName) {
	        int left = 0, right = products.length - 1;
	        while (left <= right) {
	            int mid = (left + right) / 2;
	            int cmp = products[mid].productName.compareToIgnoreCase(targetName);
	            if (cmp == 0) return products[mid];
	            if (cmp < 0) left = mid + 1;
	            else right = mid - 1;
	        }
	        return null;
	    }

	    public static void main(String[] args) {
	    
	        System.out.println("🔍 Big O Notation Overview:");
	        System.out.println(" - Describes algorithm efficiency based on input size (n)");
	        System.out.println(" - Linear Search: O(n)");
	        System.out.println(" - Binary Search: O(log n)");
	        System.out.println(" - Best Case: Found early");
	        System.out.println(" - Average Case: Middle of array");
	        System.out.println(" - Worst Case: Not found or last element\n");

	     
	        Product[] products = {
	            new Product(101, "Laptop", "Electronics"),
	            new Product(102, "Shoes", "Footwear"),
	            new Product(103, "T-Shirt", "Clothing"),
	            new Product(104, "Blender", "Kitchen"),
	            new Product(105, "iPhone", "Electronics")
	        };

	    
	        System.out.println("🔎 Linear Search for 'Laptop':");
	        Product resultLinear = linearSearch(products, "Laptop");
	        System.out.println(resultLinear != null ? "Found: " + resultLinear : "Not Found");

	        Arrays.sort(products, Comparator.comparing(p -> p.productName.toLowerCase()));

	      
	        System.out.println("\n🔎 Binary Search for 'Laptop':");
	        Product resultBinary = binarySearch(products, "Laptop");
	        System.out.println(resultBinary != null ? "Found: " + resultBinary : "Not Found");

	        System.out.println("\n📊 Time Complexity Comparison:");
	        System.out.println(" - Linear Search: O(n) → No need to sort, but slower for large data");
	        System.out.println(" - Binary Search: O(log n) → Much faster, but array must be sorted");
	        System.out.println("✅ Recommended: Use Binary Search for large, sorted product lists.");
	    }
	}
