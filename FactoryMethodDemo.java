package assignment1;

public class FactoryMethodDemo {
	

	    
	    interface Document {
	        void open();
	    }

	
	    static class WordDocument implements Document {
	        public void open() {
	            System.out.println("Opening Word Document...");
	        }
	    }

	    static class PdfDocument implements Document {
	        public void open() {
	            System.out.println("Opening PDF Document...");
	        }
	    }

	    static class ExcelDocument implements Document {
	        public void open() {
	            System.out.println("Opening Excel Document...");
	        }
	    }

	
	    abstract static class DocumentFactory {
	        public abstract Document createDocument();
	    }


	    static class WordDocumentFactory extends DocumentFactory {
	        public Document createDocument() {
	            return new WordDocument();
	        }
	    }

	    static class PdfDocumentFactory extends DocumentFactory {
	        public Document createDocument() {
	            return new PdfDocument();
	        }
	    }

	    static class ExcelDocumentFactory extends DocumentFactory {
	        public Document createDocument() {
	            return new ExcelDocument();
	        }
	    }


	    public static void main(String[] args) {
	        DocumentFactory wordFactory = new WordDocumentFactory();
	        Document word = wordFactory.createDocument();
	        word.open();

	        DocumentFactory pdfFactory = new PdfDocumentFactory();
	        Document pdf = pdfFactory.createDocument();
	        pdf.open();

	        DocumentFactory excelFactory = new ExcelDocumentFactory();
	        Document excel = excelFactory.createDocument();
	        excel.open();
	    }
	}

