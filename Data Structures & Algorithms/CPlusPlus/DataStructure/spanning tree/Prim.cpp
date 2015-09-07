//
//  main.cpp
//  Prim
//
//  Created by Sunny Jade on 9/7/15.
//  Copyright © 2015 com.appable. All rights reserved.
//

#include <iostream>
#include <string>
using namespace std;
const int n = 6;
const int maximun = 1000;


struct Edge{
    int firstVertice;
    int lastVertice;
    int value;
    bool flag;
};


void init(int a[n][n],Edge (&arrEdgePrim)[n]);
void prim(int a[n][n],Edge (&arrEdgePrim)[n]);

int countArr = 0;
int countArrResult=0;


int main(int argc, const char * argv[]) {
    //khoi tao ma tran trong so
    //ma tran vo huong la mot ma tran doi xung qua duong cheo chinh
    //A,B,C,D,E,F
    int a[n][n]={0,2,3,0,0,0,//A = 0
                2,0,8,0,0,7,//B = 1
                3,8,0,4,0,8,//C = 2
                0,0,4,0,9,0,//D = 3
                0,0,0,9,0,5,//E = 4
                0,7,8,0,5,0};//F = 5
    
    Edge arrEdgePrim[n];
    init(a, arrEdgePrim);
    prim(a,arrEdgePrim);
    return 0;
}

void init(int a[n][n],Edge (&arrEdgePrim)[n]){
    //chon row = 0
    int row = 0;
    Edge e  = Edge();e.firstVertice = -1;
    e.lastVertice = -1;
    e.value = maximun;
    e.flag = false;
    arrEdgePrim[0] = e;
    for( int col = 1; col< n; col ++){
        Edge e  = Edge();
        if(a[row][col] != 0){
            e.firstVertice = row;
            e.lastVertice = col;
            e.value = a[row][col];
            e.flag = true;//can choose
        }else{
            e.firstVertice = -1;
            e.lastVertice = -1;
            e.value = maximun;
            e.flag = true;
        }
        
        arrEdgePrim[col] = e;
    }
}
//xuat phat tu diem 0
int row = 0;
int numOfEdge = 0;

void prim(int a[n][n],Edge (&arrEdgePrim)[n]){
    //set all row of this column min
    int min = 999;
    int minEdge = 0;
    for( int i = 0; i<n ; i++){
        if(arrEdgePrim[i].value <=min && arrEdgePrim[i].flag){
            min = arrEdgePrim[i].value;
            minEdge = i;
        }
    }
    //set flag false for min Edge
    arrEdgePrim[minEdge].flag = false;
    
    numOfEdge++;
    cout<<arrEdgePrim[minEdge].firstVertice<<arrEdgePrim[minEdge].lastVertice<<"\n";
    row = arrEdgePrim[minEdge].lastVertice;
    
    
    //set value for arrEdgePrim
    for( int i = 0; i<n ; i++){
        if(arrEdgePrim[i].value > a[row][i] && a[row][i] != 0 ){
            arrEdgePrim[i].firstVertice = row;
            arrEdgePrim[i].lastVertice = i;
            arrEdgePrim[i].value = a[row][i];
        }
    }

    if(numOfEdge < n-1 ){
        prim(a,arrEdgePrim);
    }
}











