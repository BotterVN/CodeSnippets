//
//  main.cpp
//  Ha
//
//  Created by Sunny Jade on 8/27/15.
//  Copyright © 2015 com.appable. All rights reserved.
//

#include <iostream>
using namespace std;

void MovePlate(int n,int firstColum, int midleColum, int LastColum);

int main(int argc, const char * argv[]) {
    // insert code here...
    MovePlate(3, 1, 2, 3); //move 3 plate from 1 column -> 3 column
    return 0;
}
void MovePlate(int n, int firstColum, int midleColum, int LastColum){
    if( n == 1){
        cout<<"Move plate from "<<firstColum<<" to "<<LastColum<<"\n";
    }else{
        //move n-1 plate from first column to midle column
        MovePlate(n-1, firstColum, LastColum, midleColum);
        //move 1 plate from first column to last column
        MovePlate(1, firstColum, midleColum, LastColum);
        //move n-1 plate from midle comlum to last colum
        MovePlate(n-1, midleColum, firstColum, LastColum);
    }
}
