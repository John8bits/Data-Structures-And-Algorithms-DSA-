package InfixNotationEvaluation;

import java.util.Scanner;

public class Main {

    static Scanner s = new Scanner(System.in);

    public static void main(String[] args) {
    	
        System.out.print("Enter infix expression (e.g., 3+4*2): ");
        String infix = s.nextLine().replaceAll("\\s+", ""); // remove spaces

        InfixToPostfix converter = new InfixToPostfix();
        String postfix = converter.convert(infix);

        System.out.println("Postfix: " + postfix);
    }
}

//char stack
class CharStack {
	
    private char[] stack;
    private int top;

    public CharStack(int size) {
        stack = new char[size];
        top = -1;
    }

    public void push(char val) {
        stack[++top] = val;
    }

    public char pop() {
        return stack[top--];
    }

    public char peek() {
        return stack[top];
    }

    public boolean isEmpty() {
        return top == -1;
    }
}

//int stack
class IntStack {
    private int[] stack;
    private int top;

    public IntStack(int size) {
        stack = new int[size];
        top = -1;
    }

    public void push(int val) {
        stack[++top] = val;
    }

    public int pop() {
        return stack[top--];
    }

    public boolean isEmpty() {
        return top == -1;
    }
}

// Converts infix to postfix using arrays
class InfixToPostfix {

    public String convert(String infix) {
    	
        CharStack operatorStack = new CharStack(100);
        char[] postfix = new char[200];  // max size
        int pIndex = 0;

        for (int i = 0; i < infix.length(); i++) {
            char ch = infix.charAt(i);

            if (isDigit(ch)) {
            	
                postfix[pIndex++] = ch;
                postfix[pIndex++] = ' ';
                
            } else if (ch == '(') {
                
            	operatorStack.push(ch);
            
            } else if (ch == ')') {
            
            	while (!operatorStack.isEmpty() && operatorStack.peek() != '(') {
            		
                    postfix[pIndex++] = operatorStack.pop();
                    postfix[pIndex++] = ' ';
                    
                }
                operatorStack.pop(); // pop '('
                
                
            } else if (isOperator(ch)) {
            	
                while (!operatorStack.isEmpty() &&
                        precedence(operatorStack.peek()) >= precedence(ch)) {
                    postfix[pIndex++] = operatorStack.pop();
                    postfix[pIndex++] = ' ';
                }
                
                operatorStack.push(ch);
            }
            
        }

        while (!operatorStack.isEmpty()) {
        	
            postfix[pIndex++] = operatorStack.pop();
            postfix[pIndex++] = ' ';
            
        }

        // Convert the char array to string
        char[] trimmedPostfix = new char[pIndex];
        
        for (int i = 0; i < pIndex; i++) {
        	
            trimmedPostfix[i] = postfix[i];
            
        }

        return new String(trimmedPostfix); // convert the trimmed array
    }

    private boolean isOperator(char ch) {
        return ch == '+' || ch == '-' || ch == '*' || ch == '/';
    }

    private int precedence(char ch) {
    	
        if (ch == '+' || ch == '-') return 1;
        if (ch == '*' || ch == '/') return 2;
        
        return 0;
    }

    private boolean isDigit(char ch) {
        return ch >= '0' && ch <= '9';
    }
}

