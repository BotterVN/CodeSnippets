//
//  main.cpp
//  Circle
//
//  Created by Sunny Jade on 8/24/15.
//  Copyright © 2015 com.appable. All rights reserved.
//

#include <iostream>
using namespace std;
const int n = 10;

struct Node {
    int value;
    Node *pNext;
};
struct ListNode{
    Node *pHead;
};
//declare function
ListNode createLinkList (int arrValue[], ListNode &listnode);
bool searchElement ( ListNode listnode,int x);
ListNode addElementAfter (ListNode &listnode,int x,int value);
ListNode removeElementAfter (ListNode &listnode,int x);
void printListNode(ListNode listnode);

int main(int argc, const char * argv[]) {
    // insert code here...
    int arr[n] = { 1,5,2,7,9,7,10,8, 6,0};
    //init ListNode
    ListNode listnode;
    listnode.pHead = NULL;
    
    //create cricle link list
    createLinkList(arr, listnode);
    printListNode(listnode);
    
    //search element has value = x
    cout<<"\n search result: "<< searchElement(listnode, 3);
    
    //add 1 element after a element has value = x
    addElementAfter(listnode,0, 11);
    printListNode(listnode);
    
    
    //remove element has value = x
    removeElementAfter(listnode, 0);
    printListNode(listnode);
    
    return 0;
}

//create circle link list
ListNode createLinkList (int arrValue[], ListNode &listnode){
    Node *pTail = NULL;//save last element
    for( int i = 0 ; i < n; i++) {
        Node *p = new Node();
        p->value =  arrValue[i];
        if(listnode.pHead == NULL){
            p->pNext = NULL;
            listnode.pHead = pTail = p;
        }else{
            pTail->pNext = p;
            pTail = p;
        }
    }
    pTail->pNext = listnode.pHead;
    return listnode;
}

//search element with value = x
bool searchElement ( ListNode listnode, int x){
    Node * p = listnode.pHead;
    bool first = true;
    while (p != listnode.pHead || first == true) {
        first = false;
        if( p->value == x){
            return true;
        }
        p = p->pNext;
    }
    return false;
    
}

//add element after a node has value x
ListNode addElementAfter (ListNode &listnode,int x,int value){
    
    Node * p = listnode.pHead;
    bool first = true;
    while (p != listnode.pHead || first == true) {
        first = false;
        if( p->value == x){
            Node *newNode = new  Node();
            newNode->value = value;
            newNode->pNext = p->pNext;
            p->pNext = newNode;
        }
        p = p->pNext;
    }
    return listnode;
}

//remove element from listNode
ListNode removeElementAfter (ListNode &listnode,int x){
    Node * p = listnode.pHead;
    bool first = true;
    while (p != listnode.pHead || first == true) {
        first = false;
        if( p->value == x){
            Node * q = p->pNext;
            //check if element is deleted is pHead
            if( q == listnode.pHead){
                listnode.pHead = q->pNext;
            }
            
            p->pNext = q->pNext;
            q->pNext = NULL;
        }
        p = p->pNext;
    }
    return listnode;
}


//print listnode
void printListNode(ListNode listnode){
    Node * p = listnode.pHead;
    bool first = true;
    while (p != listnode.pHead || first == true) {
        first = false;
        cout<<p->value<<" ";
        p = p->pNext;
    }
    cout<<"\n";
}
