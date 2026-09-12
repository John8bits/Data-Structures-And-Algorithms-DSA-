package singlyLinkedList;

public class singleLinkedList {
	
	 int count;
	 Node head; // current
	// Node next;
	
	// insertTail, head, insertAtIndex, InsertItem, deleteTail, 
	// deleteFront,delete, deleteItem  
	
	public singleLinkedList() {
		head = null;
		count = 0;
		//next = null;
	}
	
	public void insertItem(int data) {
		
		Node nwNode = new Node(data);
		
		if(isEmpty()) {
			head = nwNode;
			//next = null;
		}else {
			// 1 2 3 --> null
			
			Node temp = head;
			
			while(temp.getNext()!=null) {
				temp = temp.getNext();	
			}
			
			temp.setNext(nwNode);
			//nwNode.setNext(null);
		}
		count++;
		
	}
		
	public void insertHead(int data) {
		
		Node nwNode = new Node(data);
		
		// 1 2 3 4 5 
		
		if(isEmpty()) {
			head = nwNode;
			//next = null;
		}else {
			// 2 1 			
			nwNode.setNext(head);
			//nwNode = nwNode.getNext();
			head = nwNode;
		}	
		count++;
	}
	
	
	public void insertTail(int data) {
		
		insertItem(data);
		
		/*Node nwNode = new Node(data);
		
		if(isEmpty()) {
			head = nwNode;
			//next = null;
		}else {
			// 2 1 --> null			
			Node temp = head;
			
			while(temp.getNext()!=null) {
				temp = temp.getNext();
			}
			temp.setNext(nwNode);		
		}	
		count++;	*/
		
	}
	
	public void insertAtIndex(int index, int data) {
			
		if(isEmpty()) {
			System.out.println("List is empty!");
		}else {
			
			// 1 2 3 4 5

			if(index < 0 || index> count) {
				System.out.println("Invalid index");
			}else if(index==0){	
				insertHead(data);	
			}else if(index==count) {
				insertTail(data);
			}else {
				
				Node nwNode = new Node(data);
				Node curr = head;	
				
				for(int i =0; i<index-1; i++) {
					curr = curr.getNext();
				}
				
				//nwNode.getNext()= curr.getNext();
				//getNext()= nwNode;
				 nwNode.setNext(curr.getNext());
		         curr.setNext(nwNode);
		        count++;
				
			}
				
		}
		
	}
	
	public void display() {
		
		Node temp = head;
		
		while(temp!=null) {
			System.out.print(temp.getData()+" ");
			temp = temp.getNext();
		}
		
	}

	public boolean isEmpty() {
		return (head==null);
	}
	
	public void deleteHead() {
		// 1 2 3 4 5
		
		head = head.getNext();		
		count--;
	}
	
	public void deleteTail() {
		// 1 2 3 4 5
		
		Node temp = head;
		
		while(temp.getNext()!=null) {
			temp = temp.getNext();
		}

		
	}
	
	
	
	
}
