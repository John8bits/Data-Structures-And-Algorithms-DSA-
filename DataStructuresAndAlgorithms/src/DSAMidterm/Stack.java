package DSAMidterm;

public class Stack {
	
	//LIFO
	Node top;
	int size;
		
	//AddBook, deleteBook, SearchBook,
	public void add(String bookIn) {
		
		Node nwBook = new Node(bookIn);
		
		if(top ==null) {
			top = nwBook;
			top.setNext(null);
		}else {
			//DSAp , Prog , PT
			//3 2 1 
			nwBook.setNext(top);
			top=nwBook;
		}
		
		System.out.println("Book Borrow: "+bookIn);
		System.out.println("Book added successfully.\n");
		size++;
	}
	
	public void display() {
		
		System.out.println("Book Display: ");
		Node temp = top;
		
		// Prog3 , Prog2 , Prog1
		
		while(temp!=null) {
			System.out.println(temp.getItem()+" ");
			temp = temp.getNext();
		}
		
	}
	
	public void delete() {
		// Prog3 , Prog2 , Prog1
		top = top.getNext();
		size--;
	}

	public void search(String bookSearch) {
		
		Node temp = top;
		boolean isFound = false;
		
		System.out.println("Search Book: "+bookSearch);
		
		while(temp!=null)
		{
			if(temp.getItem().equalsIgnoreCase(bookSearch)) {
				isFound = true;
				System.out.println("Book found");
			}
			temp = temp.getNext();
		}
		
		if(!isFound) {
			System.out.println("Book not found");
		}
		
	}
	
	
}
