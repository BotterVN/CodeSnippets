//
//  main.cpp
//  BinaryInsertionSort
//
//  Created by Sunny Jade on 8/21/15.
//  Copyright © 2015 com.appable. All rights reserved.
//

#include <iostream>
using namespace std;

const int n = 10;//number of element in array

void binaryInsertionSort(int (&arr)[n]);
void printArray(int arr[n]);

int main(int argc, const char * argv[]) {
    //array isn't sorted
    int arr[n] = {2,6,8,11,0,5,8,9,15,10};
    //function sort array
    binaryInsertionSort(arr);
    //print array after sorted
    printArray(arr);
    return 0;
}
void binaryInsertionSort(int (&arr)[n]){
    
    //get element of array
    for( int i = 1; i < n; i++ ){
        int start = 0;
        int end = i;
        int tmp = arr[i];
        //binary searh
        while (start < end) {
            int mid = (start + end)/2;
            if( arr[mid] >= arr[i]){
                end = mid;
            }else{
                start = mid + 1;
            }
        }
        //move 1 position from arr[end] to arr[i]
        for( int j = i; j > end ; j--){
            arr[j] = arr[j-1];
        }
        //set value
        arr[end] = tmp;
    }
    return;
}
void printArray(int arr[n]){
    for( int i = 1; i < n; i++ ){
        cout<<arr[i]<<" ";
    }
}




