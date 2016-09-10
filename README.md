# MyFirstComputeShader
於Unity Project中右鍵creater->Shader->ComputeShader  
來創建你第一個ComputeShader,  
double click開啟coding頁面。  

#環境設置  
在PlayerSetting中選擇如下圖的設置  
![ENV PlayerSetting](http://imgur.com/hDhidql.jpg)

# 初步Compute Shader認知 
compute shader是微軟在DirectX 11 API中新加入的，  
程式人員可以直接在GPU中執行運算能力、3D渲染等能力。  
Unity目前支持DX11所以只針對Windows平台。  
許多時候會使用Compute Shader來製作Particle效果  
![particle](http://imgur.com/FKJORjF.jpg)  

##compute shader基礎認識  
![first cs](http://imgur.com/oCzBdbt.jpg)  
上圖為我們第一個創建的compute shader，  
在第2行中定義了：  
compute shader的進入點，  
一個compute shader可以有多個進入點，    
目前我們只有一個CSMain這個進入點。  

在第3行中定義了：
可讀寫(RW開頭)的data type，  
他表示了一個Texture2D，  
每個position有4個floats(16bytes)供存取。  
若沒有RW開頭，則表示僅可讀取。  

在第9行中：
numthreads表示了幾個維度，  
在這裡我們是2維，  
每個Group會有8*8=64個threads。  

CSMain中只是對Texture2D基礎的顏色設定。  

##運行Shader  
compute shader需要掛在腳本上來使用，  
這邊我在腳本中定義了一個public的compute shader欄位來承接。  
接著new一個RenderTexture用來賦予給compute shader中的RWTexture2D，  
同時我們設定enableRandomWrite，  
這可以讓compute shader擁有對這張紋理的寫入權限。  
執行SetTexture讓shader需要的資料由CPU傳到GPU中。  
而每個thread group大小在numthreads中指定了，  
在這生成的thread數量如下：  
64 * 64 (thread groups) * 64 (threads in each group)

#執行結果  
![final](http://imgur.com/oegCkdt.jpg)
