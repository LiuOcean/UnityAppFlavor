// 请修改为自己的包名
package com.company.uaf;


import android.content.ComponentName;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.content.res.Configuration;
import android.os.Bundle;
import android.util.Log;

import com.unity3d.player.UnityPlayer;
import com.unity3d.player.BuildConfig;
import com.unity3d.player.UnityPlayerActivity;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

public class MainActivity extends UnityPlayerActivity {

    protected UAFProxy proxy;

    public void setProxy(U8Proxy proxy) {
        this.proxy = proxy;
    }

    public void init() {
        proxy.OnInitResultInternal(1, "");
    }
    
    public String getChannel() {
        return BuildConfig.CHANNEL;
    }

    public void login(String account) {
    }

    @Override
    protected void onCreate(Bundle bundle) {
        super.onCreate(bundle);
    }
    
   @Override
   public void onActivityResult(int requestCode, int resultCode, Intent data){
       super.onActivityResult(requestCode, resultCode, data);
   }
    
   @Override
   public void onStart(){
       super.onStart();
   }
    
   @Override
   public void onPause(){
       super.onPause();
   }
    
   @Override
   public void onResume(){
       super.onResume();
   }
    
   @Override
   public void onNewIntent(Intent newIntent){
       super.onNewIntent(newIntent);
   }
    
   @Override
   public void onStop(){
       super.onStop();
   }
    
   @Override
   public void onDestroy(){
       super.onDestroy();
   }
    
   @Override
   public void onRestart(){
       super.onRestart();
   }
    
   @Override
   public void onConfigurationChanged(Configuration newConfig) {
       super.onConfigurationChanged(newConfig);
   }
    
   @Override
   public void onRequestPermissionsResult(int requestCode, String[] permissions, int[] grantResults){
   }
}
