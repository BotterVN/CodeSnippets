//
//  main.cpp
//  TreeMathExpression
//
//  Created by Sunny Jade on 8/24/15.
//  Copyright © 2015 com.appable. All rights reserved.
//

#include <iostream>
#include <stack>
#include <string>
#include <queue>
using namespace std;

//struct Tree
struct TreeNode{
    string value;
    TreeNode *nodeLeft;
    TreeNode *nodeRight;
};


queue<string> postFix(string expression);
void printPostfix(queue<string> myQueue);


stack<int> stackCaculate;

TreeNode buildTree(queue<string> myQueue);
void LeftRightNode(TreeNode *rootNode);
stack<int> caculateTreeExpression(TreeNode *rootNode);

bool checkOperator ( string str);
int levelOperator (string str);


int main(int argc, const char * argv[]) {
    queue<string> myQueue;//save postfix
    
    // insert code here...
    string expression = "((1+3-2)*4-6)*10";
    
    //change math expression -> postfix
    myQueue = postFix(expression);
    cout<<"postfix math expression: ";
    printPostfix (myQueue);
    
    
    //build tree
    TreeNode myTree =  buildTree(myQueue);
    TreeNode *rootNode = &myTree;
    
    //Left Right Node display
    cout<<"display tree math expression due to Left right node: ";
    LeftRightNode(rootNode);
    
    //caculate math expression
    stackCaculate = caculateTreeExpression(rootNode);
    cout<<"\n Result of expression tree is: "<<stackCaculate.top()<<"\n";
    
    return 0;
}
//this func change math expression change infix -> postfix
//then save the result to the queue, queue use for build tree
queue<string> postFix(string expression){
    queue<string> myQueue;
    stack<string> myStack;
    string number = "";
    for( int i = 0; i < expression.length(); ++i){
        
        //each element of expression
        string str = expression.substr(i, 1);
        //check if str is operator
        if( str == "("){
            myStack.push(str);
        }else if ( str == ")"){
            if( number != ""){
                myQueue.push(number);
                number = "";
            }
            while (myStack.top() != "(") {
                myQueue.push(myStack.top());
                myStack.pop();
            }
            myStack.pop();// pop "(" from stack
        }else if(checkOperator(str)){
            //put number to queue
            if( number != ""){
                myQueue.push(number);
                number = "";
            }
                while (( !myStack.empty()) && (checkOperator(myStack.top())) && (levelOperator(myStack.top()) >= levelOperator(str))) {//problem
                    myQueue.push(myStack.top());
                    myStack.pop();
                
            }
            myStack.push(str);
        }else{
            //number may be has more then one char -> 20
            number += str;
            if( i == (expression.length() - 1)){
                myQueue.push(number);
            }
        }
    }
    
    //get all operator in queue
    while (!myStack.empty()) {
        myQueue.push(myStack.top());
        myStack.pop();
    }
    return myQueue;
}

//check string is operator or not
bool checkOperator ( string str){
    if(str == "+" || str == "-" || str == "*" || str == "/"){
        return true;
    }
    return false;
}

//check level of each operator
int levelOperator (string str){
    if(str == "+" || str == "-"){
        return 0;
    }else{
        return 1;
    }
}


//print postfix math expression
void printPostfix(queue<string> myQueue){
    while (! myQueue.empty()) {
    cout<<myQueue.front()<<" ";
    myQueue.pop();
    }
}


//build tree due to queue
TreeNode buildTree(queue<string> myQueue){
    stack<TreeNode*> treeStack;
    while (!myQueue.empty()) {
        string x = myQueue.front();
        myQueue.pop();
        TreeNode *node = new TreeNode();
        node->value = x;
        if(!checkOperator(x)){
            node->nodeLeft = node->nodeRight= NULL;//leaf
           
        }else{
            
            node->nodeRight = treeStack.top();
            treeStack.pop();
            node->nodeLeft = treeStack.top();
            treeStack.pop();
        }
        treeStack.push(node);
    }
    return *treeStack.top();
}

//display tree has built by left -> right -> operator
void LeftRightNode(TreeNode *rootNode){
    if( rootNode != NULL){
        LeftRightNode(rootNode->nodeLeft);
        
        LeftRightNode(rootNode->nodeRight);
        cout<<rootNode->value<<" ";
        
    }
}

//caculate the result of math expression due to tree
stack<int> caculateTreeExpression(TreeNode *rootNode){
    if( rootNode != NULL){
        
        caculateTreeExpression(rootNode->nodeLeft);
        caculateTreeExpression(rootNode->nodeRight);
        string str = rootNode->value;
        if(!checkOperator(str)){
            stackCaculate.push(stoi(str));
        }else{
            int b = stackCaculate.top();
            stackCaculate.pop();
            int a = stackCaculate.top();
            stackCaculate.pop();
            //check
            if(rootNode->value == "+"){
                stackCaculate.push(a+b);
            }else if(rootNode->value == "-"){
                stackCaculate.push(a-b);
            }else if(rootNode->value == "*"){
                stackCaculate.push(a*b);
            }else if(rootNode->value == "/"){
                stackCaculate.push(a/b);
            }
            
            
        }
    }
    
    return stackCaculate;//is a result
}










