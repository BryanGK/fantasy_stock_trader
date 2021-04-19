import React from 'react';
import { Chart } from 'react-google-charts';

function SummaryChart() {
    return (
        <div className="summary-chart">
            <Chart
                width={'500px'}
                height={'300px'}
                chartType="PieChart"
                loader={<div>Loading Chart</div>}
                data={[
                    ['Stock', 'Value'],
                    ['APPL', 20],
                    ['TSLA', 25],
                    ['GOOG', 30],
                    ['NFLX', 35],
                    ['GME', 100]
                ]}
                options={{
                    title: 'Current Holdings',
                    is3D: true,
                }}
                rootProps={{ 'data-testid': '2' }}
            />
        </div>
    )
}

export default SummaryChart;