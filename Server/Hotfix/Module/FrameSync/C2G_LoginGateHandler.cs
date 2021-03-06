﻿using System;
using ETModel;

namespace ETHotfix
{
    /// <summary>
    /// 网关服务器 对玩家进行管理，对ActorMessage消息进行管理
    /// </summary>
    [MessageHandler(AppType.Gate)]
	public class C2G_LoginGateHandler : AMRpcHandler<C2G_LoginGate, G2C_LoginGate>
	{
		protected override void Run(Session session, C2G_LoginGate message, Action<G2C_LoginGate> reply)
		{
			G2C_LoginGate response = new G2C_LoginGate();
			try
			{
                //在Gate服务器中对传递过来的key进行验证  （每20秒KEY失效）
                string account = Game.Scene.GetComponent<GateSessionKeyComponent>().Get(message.Key);
				if (account == null)
				{
					response.Error = ErrorCode.ERR_ConnectGateKeyError;
					response.Message = "Gate key验证失败!";
					reply(response);
					return;
				}
                //传进用户帐号
                Player player = ComponentFactory.Create<Player, string>(account);
				Game.Scene.GetComponent<PlayerComponent>().Add(player);  //添加到用户管理组件
                session.AddComponent<SessionPlayerComponent>().Player = player;
				session.AddComponent<MailBoxComponent, string>(ActorInterceptType.GateSession);

				response.PlayerId = player.Id;  //给客户端返回的用户ID
                reply(response);
                //给客户端发送热更测试
                session.Send(new G2C_TestHotfixMessage() { Info = "recv hotfix message success" });
			}
			catch (Exception e)
			{
				ReplyError(response, e, reply);
			}
		}
	}
}