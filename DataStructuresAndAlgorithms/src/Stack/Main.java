package Stack;

public class Main {

	public static void main(String[] args) {
		
		//stack s =  new stack();
		//s.push("a");
		
		stack.push("a");
		stack.push("b");
		stack.push("c");
		stack.push("d");
		stack.push("e");
		System.out.println(stack.size);
		stack.print();
		System.out.println("POP");
		stack.pop();
		stack.pop();
		stack.print();
		
		
	}

}



