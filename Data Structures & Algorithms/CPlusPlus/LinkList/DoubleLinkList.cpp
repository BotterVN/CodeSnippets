//
//  main.cpp
//  DoubleLinkList
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
    Node *pPrev;
};
struct ListNode{
    Node *pHead;
    Node *pTail;
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
    listnode.pHead = listnode.pTail = NULL;
    
    //create cricle link list
    createLinkList(arr, listnode);
    printListNode(listnode);
    
    //search element has value = x
    cout<<"\n search result: "<< searchElement(listnode, 10)<<"\n";
    
    //add 1 element after a element has value = x
    addElementAfter(listnode,0, 0);
    printListNode(listnode);
    
    
    //remove element has value = x
    removeElementAfter(listnode, 7);
    printListNode(listnode);
    
    return 0;
}

//create circle link list
ListNode createLinkList (int arrValue[], ListNode &listnode){
    //first element
    Node *p = new Node();
    p->value =  arrValue[0];
    p->pNext = NULL;
    p->pPrev = NULL;
    listnode.pHead = listnode.pTail = p;
    
    for( int i = 1 ; i < n; i++) {
        Node *p = new Node();
        p->value =  arrValue[i];
        listnode.pTail->pNext = p;
        p->pPrev = listnode.pTail;
        listnode.pTail = p;
    }
    listnode.pTail->pNext = NULL;
    return listnode;
}

//search element with value = x
bool searchElement ( ListNode listnode, int x){
    Node * p = listnode.pHead;
    while (p != NULL) {
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
    while (p != NULL) {
        if( p->value == x){
            Node *newNode = new  Node();
            newNode->value = value;
            if( p == listnode.pTail){
                p->pNext = newNode;
                newNode->pPrev = p;
                newNode->pNext = NULL;
                listnode.pTail = newNode;
            }else{
                newNode->pNext = p->pNext;
                p->pNext->pPrev = newNode;
                newNode->pPrev = p;
                p->pNext = newNode;
            }
            p = newNode;
        }
        p = p->pNext;
    }
    return listnode;
}

//remove element from listNode
ListNode removeElementAfter (ListNode &listnode,int x){
    Node * p = listnode.pHead;
   
    while (p != NULL && p->pNext != NULL) {
        if( p->value == x){
            Node * q = p->pNext;
            //check if element is deleted is pHead
            if( q == listnode.pTail){
                p->pNext = NULL;
                q->pPrev = NULL;
                listnode.pTail = p;
            }else{
                p->pNext = q->pNext;
                q->pNext->pPrev = p;
                //xoa q
                q->pNext = NULL;
                q->pPrev = NULL;
            }
            
            
            
        }
        p = p->pNext;
    }
    return listnode;
}


//print listnode
void printListNode(ListNode listnode){
    Node * p = listnode.pHead;
    while (p != NULL) {
        cout<<p->value<<" ";
        p = p->pNext;
    }
    cout<<"\n";
}