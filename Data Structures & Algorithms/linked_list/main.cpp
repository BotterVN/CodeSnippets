//
//  main.cpp
//  linked_list
//
//  Created by NGUYEN NGOC VU ANH on 8/2/15.
//  Copyright © 2015 NGUYEN NGOC VU ANH. All rights reserved.
//

#include <iostream>
#include <string>

using namespace std;

#define SAFE_DELETE(p) delete p; p = NULL;

template<typename T>
struct Node
{
    T value;
    Node* next;
    Node() { next = NULL; }
    Node(T& v, Node* n = NULL) : value(v), next(n) {}
    Node(T&& v, Node* n = NULL) : value(v), next(n) {}
};

template<typename T>
class LinkedList
{
protected:
    Node<T>* root;
    unsigned int length;
    
    
public:
    LinkedList()
    {
        length = 0;
        root = NULL;
    }
    
    virtual ~LinkedList()
    {
        clear();
    }
    
    Node<T>* begin()
    {
        return root;
    }
    
    void clear()
    {
        while (root != NULL)
        {
            Node<T>* p = root;
            root = root->next;
            SAFE_DELETE(p);
        }
        length = 0;
    }
    
    inline unsigned int getLength() { return length; }
    void append(T& t)
    {
        length++;
        Node<T>* n = new Node<T>(t, NULL);
        if (root == NULL)
        {
            root = n;
            return;
        }
        Node<T>* r = root;
        while (r->next != NULL) r = r->next;
        r->next = n;
    }
    
    bool insert(T&& t, int index)
    {
        return insert(t, index);
    }
    
    bool insert(T& t, int index)
    {
        if (index < 0 || index > length) return false;
        length++;
        if (index == 0)
        {
            root = new Node<T>(t, root);
            return  true;
        }
        
        Node<T>* r = root;
        int i = 0;
        
        while (r != NULL)
        {
            if (i == index - 1)
            {
                r->next = new Node<T>(t, r->next);
                return true;
            }
            i++;
            r = r->next;
        }
        // this code never run because have checked range above
        return false;
    }
    
    bool remove(int index)
    {
        if (index < 0 || index >= length) return false;
        length--;
        if (index == 0)
        {
            Node<T>* n = root;
            root = root->next;
            SAFE_DELETE(n);
            return true;
        }
        Node<T>* r = root;
        int i = 0;
        while (r != NULL)
        {
            if (i == index - 1)
            {
                Node<T>* n = r->next;
                r->next = r->next->next;
                SAFE_DELETE(n);
                return true;
            }
            i++;
            r = r->next;
        }
        // this code never run because have checked range above
        return false;
    }
};

void print(LinkedList<int>& list)
{
    Node<int>* n = list.begin();
    string str = "";
    while (n != NULL)
    {
        str += to_string(n->value);
        if (n->next != NULL) str += ",";
        n = n->next;
    }
    cout << "list: " << str << endl;
}

int main(int argc, const char * argv[])
{
    // insert code here...
    LinkedList<int> list;
    for (int i = 0; i < 5; i++)
    {
        list.append(i);
    }
    cout << "org list ----------------\n";
    print(list);
    cout << "insert 999 at 1 -------------\n";
    list.insert(999, 1);
    print(list);
    cout << "remove 999 at 1 -------------\n";
    list.remove(1);
    print(list);
    cout << "remove last ------------\n";
    list.remove(4);
    print(list);
    cout << "remove first ------------\n";
    list.remove(0);
    print(list);
    return 0;
}
