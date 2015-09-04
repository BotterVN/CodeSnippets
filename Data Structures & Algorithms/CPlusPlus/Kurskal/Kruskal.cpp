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
    int lastVertic;
    int value;
    bool flag;//canh co the chon dc -> true
};

void binaryInsertionSort(Edge (&arrEdge)[m]);
void setValueEdge(int a[n][n],Edge (&arrEdge)[m]);
void Kruskal(Edge arrEdge[m]);
bool checkCircle(int first, int last,Edge result[]);
int countArr = 0;
int countArrResult=0;


int main(int argc, const char * argv[]) {
    //khoi tao ma tran trong so
    //ma tran vo huong la mot ma tran doi xung qua duong cheo chinh
               //A,B,C,D,E,F
    int a[n][n]={0,2,3,0,0,0,//A = 0
                 2,0,8,0,0,0,//B = 1
                 3,8,0,4,0,8,//C = 2
                 0,0,4,0,9,0,//D = 3
                 0,0,0,9,0,5,//E = 4
                 0,0,8,0,5,0};//F = 5
    int arrVertice[n] = {0,1,2,3,4,5};
    Edge arrEdge[m]={};
    //khoi tao tap canh
    setValueEdge(a, arrEdge);
    
    //sap xep theo trong so tang dang
    binaryInsertionSort(arrEdge);
   
   
    //thuat toan Kural
    Kruskal(arrEdge);
    return 0;
}

void setValueEdge(int a[n][n],Edge (&arrEdge)[m]){
    //ma tran doi xung, nen chi can xet tam giac tren
    for(int i = 0; i < n; i++){
        for(int j = i+1; j<n;j++){
            if(a[i][j] != 0){
                Edge e = Edge();
                e.firstVertice = i;
                e.lastVertic = j;
                e.value = a[i][j];
                e.flag = true;
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
void Kruskal(Edge arrEdge[countArr]){
    Edge result[countArr];
    result[0] = arrEdge[0];
    result[1] = arrEdge[1];
    countArrResult = 2;
    for( int i = 2; i< countArr ; i++){
        //xet 2 diem co diem nao tao thanh chu trinh khong
        int first = arrEdge[i].firstVertice;
        int last = arrEdge[i].lastVertic;
        //set flag
        for( int i = 0 ;i < countArrResult; i ++ ){
            result[i].flag = true;
        }
        
        
        if(!checkCircle(first, last, result)){
            result[countArrResult] = arrEdge[i];
            countArrResult++;
            result[countArrResult] = arrEdge[i];
        }
        if( countArrResult == n-1){
            break;
        }
        
    }
    //print ket qua
    for( int i = 0; i< countArrResult; i++){
        cout<<result[i].firstVertice<<result[i].lastVertic<<"\n";
    }
    
}

bool checkCircle(int first, int last,Edge result[]){
    for( int i = 0; i< countArrResult; i++){
        
        if( result[i].flag){
            if(result[i].firstVertice == first){
                if(result[i].lastVertic == last){
                    return true;//tao chu trinh
                    
                }
                int tmp = result[i].lastVertic;
                result[i].flag = false;
                return checkCircle(tmp, last, result);
            
            
            }else if(result[i].lastVertic == first){
                if(result[i].firstVertice == last){
                    return true;//tao chu trinh
                }
                int tmp = result[i].firstVertice;
                result[i].flag = false;
                return checkCircle(tmp, last, result);
            
            }
        }
    }
    
    return false;
}







