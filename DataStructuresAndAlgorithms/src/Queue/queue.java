package Queue;

public class queue {
	
	Node front;
	Node rear;
	private int size;
	
	//enqueueBook, dequeueBook, displayB, searchB(w its index), size
	
	public void enqueueBook(String book) {
		
		Node nwBook = new Node(book);
		
		if(front == null) {
			front = nwBook;
			rear = nwBook;
		}else {
			// 1 2  
			rear.setNext(nwBook);
			rear = nwBook;
		}
		
		System.out.println("\nBorrow Book: "+book);
		System.out.println("Book enqueued successfully.");
		
		size++;
		
	}
	
	public void dequeueBook() {
		
		if(isEmpty()) {
			System.out.println("Queue is empty");
		}else {
			//Prog, DSA, PT
			System.out.println("\nReturn Book: "+front.getItem());
			front = front.getNext();
		}
		
		//System.out.println("\nReturn Book: "+front.getItem());
		System.out.println("Book dequeued successfully");
		size--;
	}
	
	public void display() {
		
		Node temp = front;
		
		if(isEmpty()) {
			System.out.println("Queue is empty");
			return;
		}else {
		
			System.out.println("\nDisplay All:");
			
			while(temp!=null) {
				System.out.println(temp.getItem());
				temp = temp.getNext();
			}
		}
	}
	
	public void search(String sBook) {
		
		if(isEmpty()) {
			System.out.println("Queue is empty");
			return;
		}else {
			int i =0;
			boolean isFound = false;
			
			Node temp = front;
			
			while(temp!=null) {
				
				if(temp.getItem().equalsIgnoreCase(sBook)) {
					isFound = true;
					System.out.printf("Book found %s at position %s",sBook,i);
				}
				
				temp = temp.getNext();
				i++;
			}
			
			if(!isFound) {
				System.out.println("\nBook not found\n");
			}
			
			
		}
		
	}
	
	public int Size() {
		System.out.println("\nTotal Count: "+size);
		return size;
	}
	
	
	public boolean isEmpty() {
		return (size==0) ? true: false;
	}
	
	
	
}
