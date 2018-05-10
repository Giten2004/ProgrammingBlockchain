https://www.jianshu.com/p/491609b1c426

【方法一】
        1.克隆项目，子模块目录默认被克隆，但是是空的
          $ git clone https://github.com/chaconinc/MainProject
        2.初始化子模块：初始化本地配置文件
          $ git submodule init
        3.该项目中抓取所有数据并检出父项目中列出的合适的提交
          $ git submodule update
【方法二：】用--recursive命令，跟方法一样达到效果
          $ git clone --recursive https://github.com/chaconinc/MainProject



更新子模块代码(需要进入子项目目录)
【方法一】
          $ cd DbConnector
          $ git fetch
          $ git merge origin/master
【方法二】
          $ git submodule update --remote DbConnector
    
      # 这里默认更新master分支，如果更新其他分支
         $ git config -f .gitmodules submodule.DbConnector.branch stable
  
         $ git submodule update --remote
         $ git merge origin/master

