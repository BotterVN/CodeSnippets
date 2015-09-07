//
//  main.cpp
//  Kruskal
//
//  Created by Sunny Jade on 9/2/15.
//  Copyright © 2015 com.appable. All rights reserved.
//

#include <iostream>
#include <string>
using namespace std;
const int n = 6;
const int m = 20;


struct Edge{
    int firstVertice;
    int lastVertice;
    int value;
};

void binaryInsertionSort(Edge (&arrEdge)[m]);
void setValueEdge(int a[n][n],Edge (&arrEdge)[m]);
void Kruskal(Edge arrEdge[m]);
bool checkInclude(int x, int arrVertice[n]);
int countArr = 0;
int countArrEdge=0;
int countArrVertice=0;


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
    
    Edge arrEdge[m]={};
    
    //tao array luu struct canh
    setValueEdge(a, arrEdge);
    
    //sap xep cac canh theo trong so tang dan
    binaryInsertionSort(arrEdge);
    
    //thuat toan Kruskal
    Kruskal(arrEdge);
    //print result
    for(int i = 0; i < countArrEdge; i++){
        cout<<arrEdge[i].firstVertice<<arrEdge[i].lastVertice<<"\n";
    }
    return 0;
}

void setValueEdge(int a[n][n],Edge (&arrEdge)[m]){
    //ma tran doi xung, nen chi can xet tam giac tren
    for(int i = 0; i < n; i++){
        for(int j = i+1; j<n;j++){
            if(a[i][j] != 0){
                Edge e = Edge();
                e.firstVertice = i;
                e.lastVertice = j;
                e.value = a[i][j];
                arrEdge[countArr] = e;
                countArr++;//dem so phan tu cua mang Edge
            }
            
        }
    }
    
}
void binaryInsertionSort(Edge (&arrEdge)[m]){
    for(int i = 1; i <countArr ;i ++){
        int low = 0;
        int high = i;
        Edge tmp = arrEdge[i];
        while (low < high) {
            int mid = (low + high)/2;
            if( arrEdge[mid].value >= arrEdge[i].value){
                high = mid;
            }else{
                low = mid + 1;
            }
        }
        for( int j = i ; j > high; j--){
            arrEdge[j] = arrEdge[j-1];
        }
        arrEdge[high] = tmp;
    }
}

/*Y tuong:
 neu 1 trong 2 dinh cua canh dang xet nam trong tap dinh da chon -> them dinh con lai vao tap dinh ket qua, them canh vao tap canh ket qua
 neu ca 2 dinh cua canh dang xet khong nam trong tap dinh da chon -> bo qua
 neu ca 2 dinh cua canh dang xet nam trong tap dinh da chon -> remove canh ra khoi tap canh ban dau
 
 dieu kien dung: khi so luong dinh da du
 
 */

void Kruskal(Edge arrEdge[countArr]){
    Edge result[countArr];//dinh chon
    int arrVertice[n] = {};//canh chon
    
    //add Dinh
    arrVertice[0] = arrEdge[0].firstVertice;
    arrVertice[1] = arrEdge[0].lastVertice;
    
    //add Canh
    result[countArrEdge] =arrEdge[0];
    
    countArrEdge = 1;
    countArrVertice = 2;
    int x = 0;
    while (countArrVertice < n-1) {//trong khi khong them dc vao arrVertice
        x = countArrVertice;
        for( int i = 1; i< countArr; i ++){
            int firstVertice = arrEdge[i].firstVertice;
            int lastVertice = arrEdge[i].lastVertice;
            bool include1 = checkInclude(firstVertice,arrVertice);
            bool include2 = checkInclude(lastVertice,arrVertice);
        //if co 1 trong 2 co trong
            if (include1 && include2){
                //remove arrEdge[i]
                for( int j = i; j<countArr; j++){
                    arrEdge[j] = arrEdge[j+1];
                }
                countArr--;
                
            }else if(include1 || include2){
                //add canh
                result[countArrEdge] = arrEdge[i];
                countArrEdge++;
                //add dinh
                arrVertice[countArrVertice] = include2?firstVertice:lastVertice;
                countArrVertice++;
            
            }
        
        }
    }
    
}


bool checkInclude(int x, int arrVertice[n]){
    for( int i = 0 ; i < countArrVertice; i++){
        if(arrVertice[i] == x){
            return true;
        }
    }
    return false;
}







