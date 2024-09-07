import React from "react";

export class Error extends React.Component<{}, {}> {
    public constructor(props: any) {
        super(props);
        this.state = {};
    }

    public componentDidMount() {
        document.title = "Error - My React Application";
    }

    public render(): JSX.Element {
        return (
            <div>
                <h1 className="text-danger">Error.</h1>
                <h2 className="text-danger">An error occurred while processing your request.</h2>
            </div>
        );
    }
}
