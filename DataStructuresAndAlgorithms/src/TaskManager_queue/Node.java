package TaskManager_queue;

public class Node {
	
	private String item;
	private Node next;
	private String item2;
	
	public Node() {
		item ="";
		next = null;
	}
	
	public Node(String item) {
		this.item =item;
		this.next = null;
	}
	
	public Node(String item, String item2) {
		this.item =item;
		this.item2 = item2;
	}	
	
	
	public Node(String item,Node next) {
		this.item =item;
		this.next = next;
	}	
	
	public String getItem() {
		return item;
	}
	public void setItem(String item) {
		this.item = item;
	}
	public Node getNext() {
		return next;
	}
	public void setNext(Node next) {
		this.next = next;
	}

	public String getItem2() {
		return item2;
	}

	public void setItem2(String item2) {
		this.item2 = item2;
	}
	
	
}
