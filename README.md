# DummyClang
## 概要
clang++に渡される引数を無理やり変更する為に使用します。
## 使い方
オリジナルの`clange++.exe`を`_clang++.exe`に置き換え、このプロジェクトでビルドした`clang++.exe`を代わりに配置します。
現在は引数から`-fvisibility=default`を削除するになっていますので、必要に応じて下記の部分を修正してお使い下さい。
 

```
 static string[,] replaceWordTbl = new string[,]
        {
          {"-fvisibility=default",""}, // 置き換えるオプション
 };
 ```
