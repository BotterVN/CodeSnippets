//
//  main.cpp
//  ConSoTuThan
//
//  Created by Sunny Jade on 9/9/15.
//  Copyright © 2015 com.appable. All rights reserved.
//

#include <iostream>
using namespace std;


struct node{
    int value;
    node* next;
};
struct listNode{
    node* pHead;
    node* pTail;
};

listNode createLink(listNode l,int n);
node* lastPersonAfterRun(listNode l,int n, int k);

int main(int argc, const char * argv[]) {
    // insert code here...
     int n = 10; int k = 4;
    listNode l = listNode();
    l.pHead = NULL;
    l.pTail = NULL;
    l = createLink(l,n);
    node* lastNode = lastPersonAfterRun(l,n,k);
    
    
    return 0;
}
listNode createLink(listNode l,int n){
    //create node 0
    node* newNode = new node();
    newNode->value = 0;
    newNode->next = NULL;
    l.pHead = l.pTail = newNode;
    
    for( int i = 1; i<n; i++){
        node* newNode = new node();
        newNode->value = i;
        l.pTail->next = newNode;
        l.pTail = newNode;
    }
    l.pTail->next = l.pHead;
    return l;
}
node* lastPersonAfterRun(listNode l,int n, int k){
    node* presentNode = l.pHead;
    node* beforePresentNode = l.pHead;
    while(beforePresentNode->next != beforePresentNode ){
        //chay den vi tri k
        for(int i= 0; i<k;i++){
            beforePresentNode = presentNode;
            presentNode = presentNode->next;
        }
        //xoa vi tri first hien tai
        beforePresentNode->next = presentNode->next;
        presentNode->next = NULL;
        presentNode = beforePresentNode;
    }
    cout<<beforePresentNode->value;
    return beforePresentNode;
}








