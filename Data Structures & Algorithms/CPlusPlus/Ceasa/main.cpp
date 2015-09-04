//
//  main.cpp
//  Ceasa
//
//  Created by Sunny Jade on 8/31/15.
//  Copyright © 2015 com.appable. All rights reserved.
//

#include <iostream>
#include <string>
using namespace std;

char encode(char c, int k);
char decode(char c, int k);

int main(int argc, const char * argv[]) {
    // insert code here...
    int k = 1305;
    string str = "AzBY";
    string result1 ="";
    if( k>26){
        k = k% 26;
    }
    //endcode
    for( int i = 0; i<str.length(); i++){
        char c = str.at(i);
        result1 += encode(c,k);
    }
    cout<<result1<<"\n";
    
    //decode
    string result2 ="";
    for( int i = 0; i<result1.length(); i++){
        char c = result1.at(i);
        result2 += decode(c,k);
    }
    cout<<result2<<"\n";
    return 0;
}

char encode(char c, int k){
    int x  = int(c);
    //chu hoa
    if( 65<=x && x<=90){
        x = x + k;
        if (x > 90){
            x = 65 + ( x- 91);
        }
        //chu thuong
    }else{
        x = x + k;
        if (x > 122){
            x = 97+( x- 123);
        }
    }
    
    return char(x);
    
}
char decode(char c, int k){
    int x  = int(c);
    //chu thuong
    if( 65<=x && x<=90){
        x = x - k;
        if (x < 65){
            x = 91 - (65-x);
        }
        //chu hoa
    }else{
        x = x - k;
        if (x < 97){
            x = 123 - (97-x);
        }
    }

    return x;
}
