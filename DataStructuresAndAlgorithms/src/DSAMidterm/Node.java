package DSAMidterm;

public class Node {

	private String item;
	private Node next;
	
	public Node() {
		this.item ="";
		this.next = null;
	}
	
	public Node(String item) {
		this.item = item;
		this.next = null;
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
	
	
}
