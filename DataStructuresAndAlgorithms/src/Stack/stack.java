package Stack;

public class stack {
	
	// {[()]}
	// LIFO
	
	static Node top;
	static int size=0;
	
	//pop(delete), push(insert)
	
	static void push(String value) {
			
		Node nwNode = new Node(value);	
		
		if(isEmpty()) {			
			top = nwNode; 
			top.next=null;
		}else {
		
		//String t = value;
		// b
		// a
			 
		nwNode.next = top;
		top = nwNode;      // b nxt a	

		}
		size++;
	}
	
	static void pop() {
		
		if(isEmpty()) {
			System.out.println("Stack is empty");
			return;
		}else {
		
		Node d = top;
		top = d.next;
		
		}
		size--;
		System.out.println("size: "+size);
		
		//e removed
		//d 
		//c
		//b
		//a
		
		/*d.next = top;
		top = null;
		top = d.next;
		top = null;
		size--;	
		*/

	}
	
	static void print() {
		
		Node t = top;
		// a b c 
		while(t!=null) {
			System.out.println(t.data + " ");
			t = t.next;
		}
		//System.out.println();
			
	}
		
	
	static boolean isEmpty() {
		/*if(size==0) {
			return true;
		}else return false;*/
		
		boolean a = (size==0)?  true:  false;  //short hand if else
		return a;
	} 
	
	
}

class Node{
	
	String data;
	Node next;
	
	Node(String data){
		this.data = data;
		next = null;
	}
	
	
}

