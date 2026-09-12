package Queue;

public class Main {

	public static void main(String[] args) {
		
		queue q = new queue();
		q.enqueueBook("Programming");
		q.enqueueBook("DSA");
		q.enqueueBook("PT");
		q.dequeueBook();
		/*q.dequeueBook();
		q.dequeueBook();
		q.dequeueBook();*/
		q.display();
		q.search("PT");
		q.Size();
	}

}
