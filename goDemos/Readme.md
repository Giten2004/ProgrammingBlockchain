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



1.新建一个分支
        $ git checkout -b add-crypto
        Switched to a new branch 'add-crypto'
2.创建一个子模块
        $ git submodule add https://github.com/chaconinc/CryptoLibrary
3.修改子模块代码，并提交
        $ git commit -am 'adding crypto library'
4.切换到master分支
        $ git checkout master
5.查看状态：
        $ git status
        On branch master
        Your branch is up-to-date with 'origin/master'.
        Untracked files:
            (use "git add <file>..." to include in what will be committed)
            CryptoLibrary/
            nothing added to commit but untracked files present (use "git add" to track)
# 这里可以看到CryptoLibrary是没有被跟踪的，这是add-crypto分支下增加的子模块的目录，特别要注意这点
6.清除未跟踪文件
        $ git clean -fdx
        Removing CryptoLibrary/
7.切换回有子模块的分支add-crypto
        $ git checkout add-crypto
        Switched to branch 'add-crypto'
8.会发现子模块的文件夹是没有的，必须重新更新
        $ ls CryptoLibrary/
        $ git submodule update --init
        $ ls CryptoLibrary/
