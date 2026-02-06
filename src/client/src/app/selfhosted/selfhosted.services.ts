import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigService } from '../shared/config.service';
import { selfHostedConstants } from '../constants/selfhosted-constants';
import { UserModel, UserTokenModel } from '../models/UserModel';
import {
  ConversationAudienceModel,
  ConversationCreateModel,
  ConversationModel,
} from '../models/ConversationModel';
import { MessageCreateModel, MessageModel } from '../models/MessageModel';

@Injectable({
  providedIn: 'root',
})
export class SelfHostedService {
  constructor(private http: HttpClient, private configService: ConfigService) { }

  private getBaseUrl(): string {
    const config = this.configService.getConfig();
    return config?.apiBaseUrl || 'http://localhost:5000';
  }

  getGroups() {
    return this.http.get<string[]>(
      `${this.getBaseUrl()}/${selfHostedConstants.CREATE_CONVERSATION_ENDPOINT}`
    );
  }

  getUsers() {
    return this.http.get<UserModel[]>(
      `${this.getBaseUrl()}/${selfHostedConstants.GET_USERS_ENDPOINT}`
    );
  }

  createUser(user: UserModel) {
    return this.http.post<UserTokenModel>(
      `${this.getBaseUrl()}/${selfHostedConstants.CREATE_USERS_ENDPOINT}`,
      user
    );
  }

  getConversations() {
    return this.http.get<ConversationModel[]>(
      `${this.getBaseUrl()}/${selfHostedConstants.GET_CONVERSATIONS_ENDPOINT}`
    );
  }

  createConversation(payload: ConversationCreateModel) {
    return this.http.post<ConversationModel>(
      `${this.getBaseUrl()}/${selfHostedConstants.GET_CONVERSATIONS_ENDPOINT}`,
      payload
    );
  }

  getConversationAudiences(conversationId: number) {
    return this.http.get<ConversationAudienceModel>(
      `${this.getBaseUrl()}/${selfHostedConstants.GET_AUDIENCES_ENDPOINT(conversationId)}`
    );
  }

  getMessages(conversationId: number) {
    return this.http.get<MessageModel[]>(
      `${this.getBaseUrl()}/${selfHostedConstants.GET_MESSAGES_ENDPOINT(conversationId)}`
    );
  }

  createMessage(payload: MessageCreateModel) {
    return this.http.post<MessageModel>(
      `${this.getBaseUrl()}/${selfHostedConstants.CREATE_MESSAGE_ENDPOINT(payload.conversationId)}`,
      payload
    );
  }

  avatarUrls: string[] = [
    'https://bootdey.com/img/Content/avatar/avatar1.png',
    'https://bootdey.com/img/Content/avatar/avatar2.png',
    'https://bootdey.com/img/Content/avatar/avatar3.png',
    'https://bootdey.com/img/Content/avatar/avatar7.png',
    'https://bootdey.com/img/Content/avatar/avatar8.png',
  ];

  getRandomAvatarUrl(): string {
    const randomIndex = Math.floor(Math.random() * this.avatarUrls.length);
    return this.avatarUrls[randomIndex];
  }
}
