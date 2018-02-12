﻿using BTreeFrame;

namespace Battle.Logic.AI.BTree
{
    class AttackActionNode : BTreeNodeAction<MyInputData, MyOutputData>
    {
        public AttackActionNode(BTreeNode<MyInputData, MyOutputData> _parentNode) 
            : base(_parentNode)
        {
        }

        protected override BTreeRunningStatus _DoExecute(MyInputData _input, ref MyOutputData _output)
        {
            var troop = _input.troop;
            var outTroop = _output.troop;
            var target = _input.battleData.mAllTroopDic[troop.targetKey];
            var tar_x = target.x;
            var tar_y = target.y;

            outTroop.dir_x = tar_x;
            outTroop.dir_y = tar_y;

            outTroop.state = (int)TroopAnimState.Attack;
            outTroop.inPrepose = true;
            outTroop.preTime = TroopHelper.GetTroopAtkPrepareTime(outTroop.type);
            outTroop.isAtk = true;
            outTroop.norAtkCD = TroopHelper.GetTroopAtkCDTime(outTroop.type);
            return BTreeRunningStatus.Finish;
        }
    }
}
