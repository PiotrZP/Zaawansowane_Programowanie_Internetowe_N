import React from "react";
import { IGroup } from "../../models/IGroup";
import { IMessage } from "../../models/IMessage";
import { IUser } from "../../models/IUser";
import { HubConnection } from "@microsoft/signalr";
// import authorizeService from '../api-authorization/AuthorizeService';

type IState = {
  message?: IMessage;
  messages: IMessage[];
  groups: IGroup[];
  users: IUser[];
  sendToType: string;
  sendUserId?: string;
  sendGroupId?: string;
};

export class Chat extends React.Component<{}, IState> {
  connection?: HubConnection;
  constructor(props: {}) {
    super(props);
    this.connection = undefined;
    this.state = {
      message: undefined,
      messages: [],
      groups: [],
      users: [],
      sendToType: "1",
      sendUserId: "0",
      sendGroupId: undefined,
    };
  }

  encodeText = (text: string) => {
    return text !== undefined
      ? text.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;")
      : "";
  };

  sendMessage = () => {
    if (this.state.message !== undefined) {
      let message = this.state.message;
      if (this.state.sendToType === "1") {
        if (this.state.sendUserId === "0")
          this.connection?.invoke("SendMessageAll", message);
        else if (this.state.sendUserId !== "0") {
          message.recipientName = this.state.users.find(
            (u) => u.id === this.state.sendUserId
          )?.userName;
          if (message.recipientName !== "0")
            this.connection?.invoke("SendMessageToUser", message);
        }
      } else if (
        this.state.sendToType === "2" &&
        this.state.sendGroupId !== undefined
      ) {
        message.recipientName = this.state.groups.find(
          (u) => u.id === this.state.sendGroupId
        )?.name;
        if (message.recipientName !== undefined)
          this.connection?.invoke("SendMessageToGroup", message);
      }
    }
  };

  onInputChange = (e: React.ChangeEvent<HTMLTextAreaElement>) => {
    let newState = { ...this.state };
    if (newState.message === undefined)
      newState.message = { content: e.target.value, recipientName: "" };
    else newState.message.content = e.target.value;
    this.setState(newState);
  };

  onSelectChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    const { name, value } = e.target;
    this.setState((state) => ({ ...state, [name]: value }));
  };

  componentDidMount = async () => {
    try {
      // BRAK AUTHORIZE SERVICE W INSTRUKCJI //
      // const token = await authorizeService.getAccessToken()
      // this.connection = new HubConnectionBuilder().withAutomaticReconnect().withUrl("/chatHub",{
      //     accessTokenFactory: async () => token, transport: HttpTransportType.LongPolling
      //     } as IHttpConnectionOptions )
      //     .build();
    } catch {}
  };
}
