//
//  main.cpp
//  100!
//
//  Created by Sunny Jade on 8/30/15.
//  Copyright © 2015 com.appable. All rights reserved.
//

#include <iostream>
#include <stdlib.h>
#include <string>
using namespace std;

string Add (string a, string b);
string Multi (string a, string b);
string factorial (int n);

int main(int argc, const char * argv[]) {
    // insert code here...
    cout<<factorial(100);
    return 0;
}

string Add (string a, string b){
    string result = "";
    //check amount of charactor of each number
    long length_a = a.length();
    long length_b = b.length();
    if(length_a < length_b){
        for( long i = length_a ; i < length_b; i++){
            a = "0" + a;
        }
    }else if(length_a > length_b){
        for( long i = length_b ; i < length_a; i++){
            b = "0" + b;
        }
    }
    int tmp = 0;
    for(long i = (b.length() - 1) ;i >= 0 ;i--){
        int x = int(a.at(i)%48);// char return ASCII
        int y = int(b.at(i)%48);
        int z = x + y +tmp;
        int mod = z%10;
        tmp = z/10;
            result = to_string(mod) + result;
    }
    if( tmp != 0){
        result = to_string(tmp) + result;
    }
    return result;
}


string Multi (string a, string b){
    string result = "";
    int tmp = 0;
    for( long i = a.length() -1 ; i >= 0; i--){
        int x = int(a.at(i)%48);
        string result_tmp = "";
        for( long j = b.length() -1 ; j >= 0; j--){
            int y = int(b.at(j)%48);
            int z = x*y+tmp;
            int mod = z%10;
            tmp = z/10;
            result_tmp = to_string(mod) + result_tmp;
        }
        //tmp
        if( tmp != 0){
            result_tmp = to_string(tmp)+ result_tmp;
            tmp=0;
        }
        //add more 0
        for( int k=a.length()-1 ; k>i; k--){
            result_tmp += "0";
        }
        
        result = Add(result, result_tmp);
    }
    return result;
    
}

string factorial (int n){
    if( n == 1){
        return "1";
    }else{
        return Multi(to_string(n), factorial(n-1));
    }
}


