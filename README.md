# CreatFolderRepo
使用在github.io Blog的輔助工具
## 功能1 自動建立圖片資料夾 
功能1 實際情況說明 :
如果 _posts\ 底下有個檔名叫做 2022-11-30-side-project-powercontroller.md  
則自動在 assets\img 底下建立名稱為 2022-11-30-side-project-powercontroller的"資料夾"  
這樣之後在2022-11-30-side-project-powercontroller.md裡面要引用圖片  
,只要統一都這樣用就行了  /assets/img/2022-11-30-side-project-powercontroller/1.png  
圖檔隨便取個流水號,使用md檔名進行圖片分類就好了  



## 功能2  PNG轉png
功能2 實際情況說明 :  
強制讓 assets\img\ 底下所有資料夾裡面的所有圖檔,附檔名全部變為小寫png  
偵測 _posts\ 底下 所有 .md的檔案裡面的文字,"顯示"有大寫PNG的段落名稱 (只做顯示,請自行去改文字)  

備註:  
之所以有功能2的原因  
因為安裝Ruby在本地看blog時, MD檔打PNG 但圖片實際是png時可以正常顯示  
但Push到github從外部網站瀏覽時,會因為大小寫有區分導致,所以檔名不一樣,會讓圖片無法正常顯示  
