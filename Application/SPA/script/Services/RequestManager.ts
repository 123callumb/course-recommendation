export default class RequestManager {
    public static async MakeRequest<T_Response = null, T_Request = null>(url: RequestURL, type: "POST" | "GET" = "GET", data?: T_Request, relative: boolean = true): Promise<BaseResponse<T_Response>> {
        try {
            let request = await fetch(relative ? url : `${location.origin}/${url}`, {
                method: type,
                headers: {
                    'Content-Type': 'application/json' // TODO: have custom ability here for req types like downloads etc :)
                },
                body: data != null ? JSON.stringify(data) : undefined
            });
            let response: BaseResponse<T_Response> = await request.json();

            if (response.success)
                return response;
            throw "Reponse success is false, server message: " + (response?.message ?? "");
        }
        catch (e) {
            return {
                success: false,
                message: e
            } as BaseResponse<T_Response>;
        }
    }

    public static ChangeURL(url: PageRoute | string, callback?: () => void): void {
        location.href = url;
        if (callback)
            callback();
    }
}

export enum RequestURL {
    Home_Load = "Home/Load",
    AnswerSet_RegisterSessionAnswer = "AnswerSet/RegisterSessionAnswer"
}

export enum PageRoute {
    Home = "/",
    Recommendation = "/Recommendation"
}

export interface BaseResponse<T> {
    success: boolean;
    data?: T;
    message?: string;
}